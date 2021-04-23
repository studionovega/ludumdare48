using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

namespace com.novega.projectLIYAVERSE
{
    public class InitializeGame : MonoBehaviour
    {
        [SerializeField] float screenTime = 5.5f;

        [SerializeField] private AudioMixer mixer;

        void Start()
        {
            //mixer = Resources.Load("Music") as AudioMixer;

            // Reset mixer volume based off of saved options
            mixer.SetFloat("Music", PlayerPrefs.GetInt("MusicVOL", 10) / 10);
        }

        // Update is called once per frame
        void Update()
        {
            screenTime -= Time.deltaTime;

            if (screenTime <= 0f)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
