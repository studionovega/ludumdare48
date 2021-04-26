using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.ludumdare48
{
    public class DestroyOnTimer : MonoBehaviour
    {
        public float timer = 1f;
        private void Start()
        {
            StartCoroutine(KillTimer());
        }

        private IEnumerator KillTimer()
        {
            yield return new WaitForSeconds(timer);
            Destroy(gameObject);
        }
    }
}
