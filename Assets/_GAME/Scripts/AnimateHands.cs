using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.ludumdare48
{
    public class AnimateHands : MonoBehaviour
    {
        public float speed = 0.4f;
        private Vector3 startPos;
        // Start is called before the first frame update
        void Start()
        {
            startPos = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.y < startPos.y + 2.28)
            {
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
                transform.position = new Vector3(startPos.x + Random.Range(-0.1f, 0.1f), transform.position.y, startPos.z + Random.Range(-0.1f, 0.1f));
            }
        }
    }
}
