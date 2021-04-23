using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.projectLIYAVERSE
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;

        public float smoothSpeed = 0.125f;
        public Vector3 offset;
        public Vector3 rotation;

        // Update is called once per frame
        void FixedUpdate()
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.rotation = Quaternion.Euler(rotation);
        }
    }
}