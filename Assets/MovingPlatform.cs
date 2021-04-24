using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.ludumdare48
{
    public class MovingPlatform : MonoBehaviour
    {
        public Vector3 delta;
        private Vector3 previousPosition;
        // Start is called before the first frame update
        void Start()
        {
            previousPosition = transform.position;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            delta = transform.position - previousPosition;
            previousPosition = transform.position;
        }
    }
}
