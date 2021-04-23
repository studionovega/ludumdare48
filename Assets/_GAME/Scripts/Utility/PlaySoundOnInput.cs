using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.projectLIYAVERSE {
    public class PlaySoundOnInput : MonoBehaviour
    {
        [SerializeField] string buttonName;
        [SerializeField] AudioSource source;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown(buttonName))
            {
                source.Play();
            }
        }
    }
}
