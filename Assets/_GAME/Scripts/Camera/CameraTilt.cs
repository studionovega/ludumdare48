using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.ludumdare48
{
    public class CameraTilt : MonoBehaviour
    {
        public float tiltX = 0f;
        public float tiltY = 0f;
        public float tiltZ = 0f;
        public float tiltXSpeed = 1f;
        public float tiltYSpeed = 1f;
        public float tiltZSpeed = 1f;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Mathf.Sin(Time.timeSinceLevelLoad * tiltYSpeed) * tiltY, Mathf.Sin(Time.timeSinceLevelLoad * tiltZSpeed) * tiltZ);
        }
    }
}
