using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.ludumdare48
{
    public class CharacterMovement : MonoBehaviour
    {
        public float moveSpeed = 1f;
        public float gravity = 40.0f;
        [SerializeField] Transform footstepsSpawn;
        [SerializeField] GameObject footstepParticles;

        private CharacterController _controller;
        private Animator _animator;
        private GameReference gameRef;
        [HideInInspector] public float hAxis, vAxis;

        public static bool freezeMovement = false; //For when menus are open and stuff.

        Vector2 storedMovement;

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
            hAxis = Input.GetAxis("Horizontal");
            vAxis = Input.GetAxis("Vertical");

            Vector3 motion = new Vector3(0.0f, 0.0f, 0.0f);

            if (freezeMovement)
            {
                hAxis = 0f;
                vAxis = 0f;
            }

            if (Mathf.Abs(hAxis) > 0.25f || Mathf.Abs(vAxis) > 0.25f)
            {
                motion.x = hAxis * (moveSpeed / 2);
                motion.z = vAxis * (moveSpeed / 2);
                storedMovement = new Vector2(hAxis, vAxis);
                _animator.SetBool("isMoving", true);
            }
            else
            {
                _animator.SetBool("isMoving", false);
            }

            motion.y -= gravity * Time.deltaTime;

            _controller.Move(motion * Time.deltaTime);
        }

        public void SpawnFootsteps() {
            Instantiate(footstepParticles, footstepsSpawn.position, footstepsSpawn.rotation);
        }
    }
}
