using System;
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
        public AudioClip gameOverB;
        private AudioClip currentSong;
        private static bool spawned = false;
        private bool original = false;

        private AudioSource _source;
        private float gameMusicPlayhead;
        void Awake()
        {
            //Make this a singleton
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

            if (spawned && !original)
            {
                Destroy(this.gameObject);
            }
            else
            {
                spawned = true;
                original = true;
                DontDestroyOnLoad(this.gameObject);
                //Accessible from any script easily because of a static reference.
                self = this;

                _source = GetComponent<AudioSource>();
                _source.loop = true;
                Debug.Log("gameMusicPlayhead init: " + gameMusicPlayhead);
            }
        }


        public void PlayMusic(AudioClip song)
        {

            //Remember where spoomk left off so players will hear the whole thing. :)
            if (currentSong == spoomk)
            {
                gameMusicPlayhead = _source.time;
                Debug.Log("gameMusicPlayhead: " + gameMusicPlayhead);
            }

            if (song == null)
            {
                Debug.LogError("That AudioClip is null!");
                return;
            }
            //Play song only if not already playing that soooong.
            if (currentSong != song)
            {
                _source.clip = song;

                if (song == spoomk)
                {
                    _source.time = gameMusicPlayhead;
                }
                else
                {
                    _source.time = 0;
                }
                _source.Play();
            }
            currentSong = song;
        }

        internal void PauseMusic()
        {
            _source.Pause();
        }
    }
}
