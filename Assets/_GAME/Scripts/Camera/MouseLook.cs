using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.ludumdare48
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] float mouseSensitivity = 5.0f;
        [SerializeField] Transform playerBody;

        float xRotation = 0f;

        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * (mouseSensitivity * 20f) * Time.deltaTime;
            float mouseY = Input.GetAxisRaw("Mouse Y") * (mouseSensitivity * 20f) * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
