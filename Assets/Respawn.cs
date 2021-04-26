using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.ludumdare48
{
    public class Respawn : MonoBehaviour
    {
        [SerializeField] private float spawnDelay = 5f;
        public void RespawnItem()
        {
            StartCoroutine(Spawn());
        }
        private IEnumerator Spawn()
        {
            gameObject.SetActive(false);
            yield return new WaitForSeconds(spawnDelay);
            gameObject.SetActive(true);
            Debug.Log("Respawned!");
        }
    }
}
