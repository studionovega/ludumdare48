using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.ludumdare48
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 1f;
        [SerializeField] float sprintMult = 1f;
        [SerializeField] float sanity = 100.0f;
        [SerializeField] float sanityDrainSpeed = 1f;
        [SerializeField] Vector2 sanityWaitTimes = new Vector2(1, 10);
        [SerializeField] float gravity = 40.0f;
        [SerializeField] float jumpHeight = 5.0f;
        [SerializeField] Transform groundCheck;
        [SerializeField] float groundDistance = 0.4f;
        [SerializeField] LayerMask groundMask;
        [SerializeField] float voidHeight = -25f;
        [SerializeField] Transform footstepsSpawn;
        [SerializeField] GameObject footstepParticles;
        [SerializeField] GameObject gameOverScreen;

        private CharacterController _controller;
        private Animator _animator;
        private GameReference gameRef;
        [HideInInspector] public float hAxis, vAxis;
        [HideInInspector] public bool isGrounded = false;
        [HideInInspector] public bool warnTrigger = false;

        public static bool freezeMovement = false; //For when menus are open and stuff.

        Camera cam;
        Vector2 storedMovement;
        Vector3 spawnPosition = Vector3.zero;
        Vector3 velocity;
        float moveMult = 0.5f;
        bool controlFlip = false;
        bool bunnyHop = false;
        bool rolling = false;
        bool gameOver = false;

        // Start is called before the first frame update
        void Start()
        {
            _controller = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
            _controller.enabled = true;
            GameReference.Assign(ref gameRef);
            cam = Camera.main;

            spawnPosition = transform.position;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            hAxis = controlFlip ? -Input.GetAxis("Horizontal") : Input.GetAxis("Horizontal");
            vAxis = controlFlip ? -Input.GetAxis("Vertical") : Input.GetAxis("Vertical");

            Vector3 motion = new Vector3(0.0f, 0.0f, 0.0f);

            if (freezeMovement)
            {
                hAxis = 0f;
                vAxis = 0f;
            }

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0f)
            {
                velocity.y = -2f;
            }

            if (Mathf.Abs(hAxis) > 0.25f || Mathf.Abs(vAxis) > 0.25f)
            {
                motion = (hAxis * transform.right) + (vAxis * transform.forward);
                storedMovement = new Vector2(hAxis, vAxis);
                if (_animator) { _animator.SetBool("isMoving", true); }
            }
            else
            {
                if (_animator) { _animator.SetBool("isMoving", false); }
            }

            _controller.Move(motion * (moveSpeed * moveMult) * Time.deltaTime);

            velocity.y -= gravity * Time.deltaTime;

            Debug.Log(isGrounded);

            _controller.Move(velocity * Time.deltaTime);

            if (transform.position.y <= voidHeight && !gameOver)
            {
                CommitDie();
            }
        }

        void Update()
        {
            if (Input.GetButtonDown("Jump") && isGrounded || bunnyHop && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * -gravity);
            }

            if (Input.GetButton("Sprint"))
            {
                moveMult = sprintMult;
            }
            else
            {
                moveMult = 0.5f;
            }

            if (!rolling)
            {
                StartCoroutine(Reroll());
            }

            sanity -= sanityDrainSpeed * Time.deltaTime;
            sanity = Mathf.Clamp(sanity, 0.0f, 100.0f);
        }

        IEnumerator Reroll()
        {
            // close loop
            rolling = true;

            // pick a number
            int pick = Random.Range(1, 101);
            int seed = Random.Range(0, 3);

            Debug.Log($"PICK: {pick}, SEED: {seed}");

            // reset before applying roll
            controlFlip = false;
            cam.fieldOfView = 70f;
            bunnyHop = false;

            // if that number is larger than your sanity, then you go insane
            if (pick >= sanity)
            {
                switch (seed)
                {
                    case 0:
                    default:
                        // control flip
                        controlFlip = true;
                        break;
                    case 1:
                        // crazy fov
                        cam.fieldOfView = 120f;
                        break;
                    case 2:
                        // bunny hop
                        bunnyHop = true;
                        break;
                }
            }
            else
            {
                // normality
                controlFlip = false;
                cam.fieldOfView = 70f;
                bunnyHop = false;
            }

            // wait for a random amount of time, then reroll
            yield return new WaitForSeconds(Random.Range(sanityWaitTimes.x, sanityWaitTimes.y));

            // warn player
            warnTrigger = true;
            yield return new WaitForSeconds(1.5f);

            // reroll
            warnTrigger = false;
            StartCoroutine(Reroll());
        }

        void CommitDie()
        {
            Instantiate(gameOverScreen);
            Cursor.lockState = CursorLockMode.None;
            gameOver = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            switch (other.tag)
            {
                case "SanityBottle":
                    Destroy(other.gameObject);
                    sanity += 50f;
                    if (sanity > 100f)
                    {
                        sanity = 100f;
                    }
                    break;
                case "TriggerDeath":
                    CommitDie();
                    break;
            }
        }

        public void SpawnFootsteps() {
            Instantiate(footstepParticles, footstepsSpawn.position, footstepsSpawn.rotation);
        }
    }
}
