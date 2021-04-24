using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace com.novega.ludumdare48
{
    public class UIS_ToggleBob : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI text;
        [SerializeField] Color onColour, offColour;
        Image button;
        int bob;

        // Start is called before the first frame update
        void Start()
        {
            // initialize variables
            button = GetComponent<Image>();

            // get bob preference; otherwise set it for first time
            if (PlayerPrefs.HasKey("EnableBob"))
            {
                bob = PlayerPrefs.GetInt("EnableBob");
            }
            else
            {
                bob = 1;
                Save();
            }

            // set text to off or on
            switch (bob)
            {
                case 0:
                default:
                    text.text = "OFF";
                    button.color = offColour;
                    break;
                case 1:
                    text.text = "ON";
                    button.color = onColour;
                    break;
            }
        }

        // Update is called once per frame
        public void UpdateSetting()
        {
            bob = bob == 1 ? 0 : 1; // toggle between 0 and 1
            Save();

            // set text to off or on
            switch (bob)
            {
                case 0:
                default:
                    text.text = "OFF";
                    button.color = offColour;
                    break;
                case 1:
                    text.text = "ON";
                    button.color = onColour;
                    break;
            }
        }

        void Save()
        {
            PlayerPrefs.SetInt("EnableBob", bob);
            PlayerPrefs.Save();
        }
    }
}
