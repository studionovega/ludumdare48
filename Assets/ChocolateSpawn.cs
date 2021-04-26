using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.ludumdare48
{
    public class ChocolateSpawn : MonoBehaviour
    {
        [SerializeField] GameObject itemToSpawn;
        [SerializeField] private float spawnDelay = 30f;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Spawn());
        }
        private IEnumerator Spawn()
        {
            Debug.Log("Respawning item in " + spawnDelay);
            yield return new WaitForSeconds(spawnDelay);
            GameObject g = Instantiate(itemToSpawn, transform.position, transform.rotation);
            Debug.Log("Chocolate!" + g);
            Destroy(gameObject); // -_- RIP
        }
    }
}
