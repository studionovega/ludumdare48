using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.ludumdare48
{
    public class ReactiveTarget : MonoBehaviour
    {
        [SerializeField] GameObject[] recipients;
        public string message = "React";
        public void ReactToHit()
        {
            foreach(GameObject g in recipients)
            {
                g.SendMessage(message);
            }
        }
    }
}
