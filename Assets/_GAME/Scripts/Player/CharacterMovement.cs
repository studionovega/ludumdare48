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
        [SerializeField] Transform footstepsSpawn;
        [SerializeField] GameObject footstepParticles;

        private CharacterController _controller;
        private Animator _animator;
        private GameReference gameRef;
        [HideInInspector] public float hAxis, vAxis;
        [HideInInspector] public bool isGrounded = false;
        [HideInInspector] public bool warnTrigger = false;

        public static bool freezeMovement = false; //For when menus are open and stuff.

        Vector2 storedMovement;
        Vector3 velocity;
        float moveMult = 0.5f;
        bool controlFlip = false;
        bool rolling = false;

        // Start is called before the first frame update
        void Start()
        {
            _controller = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
            _controller.enabled = true;
            GameReference.Assign(ref gameRef);
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
        }

        void Update()
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
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
        }

        IEnumerator Reroll()
        {
            // close loop
            rolling = true;

            // pick a number
            int pick = Random.Range(1, 100);

            // if that number is larger than your sanity, then you go insane
            if (pick >= sanity)
            {
                controlFlip = true;
            }
            else
            {
                // normality
                controlFlip = false;
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

        public void SpawnFootsteps() {
            Instantiate(footstepParticles, footstepsSpawn.position, footstepsSpawn.rotation);
        }
    }
}
