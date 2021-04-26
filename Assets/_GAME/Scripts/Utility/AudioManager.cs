using UnityEngine;
using System.Collections;

namespace com.novega.ludumdare48
{
    [RequireComponent(typeof(AudioSource))]

    public class AudioManager : MonoBehaviour
    {
        public AudioClip jump;
        public AudioClip chocolate;
        public AudioClip throwSwitch;
        public AudioClip bearTrap;
        public static AudioManager self;
        AudioSource soundSource;

        //Initialize some things.
        void Start()
        {
            //I create a new AudioSource here so that I can turn sound effects or music on/off separate from each other.
            soundSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
            self = this;
        }

        //Play the given sound effect once at the specified volume.
        public void PlayClip(AudioClip clip, float volume)
        {
            soundSource.PlayOneShot(clip, volume);
        }
    }
}