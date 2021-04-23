using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.projectLIYAVERSE
{
    public class RotateOnAxis : MonoBehaviour
    {
        public bool X, Y, Z;
        public float XSpeed, YSpeed, ZSpeed;

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(X ? XSpeed * Time.deltaTime : 0.0f,
                              Y ? YSpeed * Time.deltaTime : 0.0f,
                              Z ? ZSpeed * Time.deltaTime : 0.0f
                            );
        }
    }
}
