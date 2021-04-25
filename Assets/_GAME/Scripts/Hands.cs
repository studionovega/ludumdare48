using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.ludumdare48
{
    public class Hands : MonoBehaviour
    {
        public GameObject[] hands;

        private void Start()
        {
        }

        public void ActivateHands(int handCount)
        {
            for (int i = 0; i < handCount; i++)
            {
                int hand = Random.Range(0, hands.Length - 1);
                GameObject g = Instantiate(hands[Random.Range(0,hands.Length)]);
                g.transform.position = transform.position;
                g.transform.position += new Vector3(Random.Range(-7, 7), -3, Random.Range(-7, 7));
            }
        }
    }
}
