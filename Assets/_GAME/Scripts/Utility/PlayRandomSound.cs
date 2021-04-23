using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.projectLIYAVERSE {
    public class PlayRandomSound : MonoBehaviour
    {
        public AudioSource source;
        public AudioClip[] sounds;

        public void PlayRandom()
        {
            int i = Random.Range(0, sounds.Length - 1);

            source.clip = sounds[i];
            source.Play();
        }
    }
}
