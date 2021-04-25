using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.ludumdare48
{
    public class StickToGround : MonoBehaviour
    {
        RaycastHit hit;
        Collider col;

        private void Start()
        {
            col = GetComponent<Collider>();
        }

        void Update()
        {
            if (Physics.Raycast(transform.position, -Vector3.up * 10000f, out hit))
            {
                transform.position = new Vector3(transform.position.x, hit.distance - col.bounds.extents.y, transform.position.z);
            }
        }
    }
}
