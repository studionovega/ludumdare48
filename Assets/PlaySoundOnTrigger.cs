using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.ludumdare48
{
    public class PlaySoundOnTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            AudioManager.self.PlayClip(AudioManager.self.bearTrap, 1f);
        }
    }
}
