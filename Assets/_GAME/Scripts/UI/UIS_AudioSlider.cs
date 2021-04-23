using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace com.novega.ludumdare48
{
    public class UIS_AudioSlider : MonoBehaviour
    {
        [SerializeField] AudioMixer gameMixer;
        [SerializeField] string mixerGroup;

        Slider slider;

        // Start is called before the first frame update
        void Start()
        {
            slider = GetComponent<Slider>();

            if (PlayerPrefs.HasKey(mixerGroup + "_VOL"))
            {
                slider.value = PlayerPrefs.GetFloat(mixerGroup + "_VOL");
            }
        }

        // Update is called once per frame
        public void UpdateSetting()
        {
            var setting = slider.value;

            gameMixer.SetFloat(mixerGroup, setting);
            PlayerPrefs.SetFloat(mixerGroup + "_VOL", setting);
        }
    }
}
