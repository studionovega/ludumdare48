using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.ludumdare48
{
    public class FlipSwitchReact : MonoBehaviour
    {
        public void React()
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z * -1);
        }
    }
}
