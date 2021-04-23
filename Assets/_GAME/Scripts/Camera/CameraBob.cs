using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.ludumdare48
{
    public class CameraBob : MonoBehaviour
    {
        public float walkingBobbingSpeed = 14f;
        public float bobbingAmount = 0.05f;
        public float bobMult = 1f;
        public float sprintMult = 2f;
        public CharacterMovement controller;

        float defaultPosY = 0;
        float timer = 0;
        float defaultMult = 1f;
        int enableBob = 1;

        // Start is called before the first frame update
        void Start()
        {
            defaultPosY = transform.localPosition.y;

            if (PlayerPrefs.HasKey("EnableBob")) 
            {
                enableBob = PlayerPrefs.GetInt("EnableBob");
            }

            defaultMult = bobMult;
        }

        // Update is called once per frame
        void Update()
        {
            if (enableBob == 1)
            {
                if (Mathf.Abs(controller.hAxis) > 0.1f || Mathf.Abs(controller.vAxis) > 0.1f)
                {
                    if (controller.isGrounded)
                    {
                        //Player is moving
                        timer += Time.deltaTime * walkingBobbingSpeed * (bobMult * 0.75f);
                        transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobbingAmount * bobMult, transform.localPosition.z);
                    }
                    else
                    {
                        //Idle
                        timer = 0;
                        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * walkingBobbingSpeed), transform.localPosition.z);
                    }
                }
                else
                {
                    //Idle
                    timer = 0;
                    transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * walkingBobbingSpeed), transform.localPosition.z);
                }

                if (Input.GetButton("Sprint"))
                {
                    bobMult = sprintMult;
                }
                else
                {
                    bobMult = defaultMult;
                }
            }
        }
    }
}
