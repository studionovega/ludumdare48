using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.ludumdare48 
{
    public class PlayRandomSound : MonoBehaviour
    {
        public AudioSource source;
        public AudioClip[] sounds;
        public bool pitchBend = false;
        public Vector2 pitchMinMax;

        int recent = 0;

        public void PlayRandom()
        {
            int i = Random.Range(0, sounds.Length - 1);

            source.clip = sounds[i];
            if (pitchBend)
            {
                source.pitch = Random.Range(pitchMinMax.x, pitchMinMax.y);
            }
            source.Play();
        }

        public void PickSound(bool repeatSounds, float volumeScale)
        {
            //Play a random sound from a list.
            //if repeatSounds is false, retry if we roll the same sound twice.
            int i = Random.Range(0, sounds.Length);

            if (!repeatSounds)
            {
                while (recent == i)
                {
                    i = Random.Range(0, sounds.Length);
                }
            }

            recent = i;

            if (pitchBend)
            {
                source.pitch = Random.Range(pitchMinMax.x, pitchMinMax.y);
            }
            source.PlayOneShot(sounds[i], volumeScale);
        }
    }
}
