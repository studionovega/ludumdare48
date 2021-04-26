using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.ludumdare48
{
    [RequireComponent(typeof(AudioSource))]

    public class MusicManager : MonoBehaviour
    {

        public static MusicManager self;

        [SerializeField]
        public AudioClip spoomk;
        public AudioClip gameOver;
        private AudioClip currentSong;

        private AudioSource _source;
        void Awake()
        {
            //Make this a singleton
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

            if (objs.Length > 1)
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);
            //Accessible from any script easily because of a static reference.
            self = this;

            _source = GetComponent<AudioSource>();
            _source.loop = true;

            Debug.Log("self = " + self);
        }


        public void PlayMusic(AudioClip song)
        {
            if (song == null)
            {
                Debug.Log("That AudioClip is null!");
                return;
            }
            //Play song only if not already playing that soooong.
            if (currentSong != song)
            {
                _source.clip = song;
                _source.Play();
            }
        }
    }
}
