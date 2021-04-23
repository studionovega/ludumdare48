using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace com.novega.ludumdare48
{
    public class UIS_SetGraphics : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI text;

        int graphicsLevel;

        private void Start()
        {
            graphicsLevel = PlayerPrefs.GetInt("GraphicsSetting", 2);
            UpdateText();
        }

        // Start is called before the first frame update
        public void SetLevel()
        {
            graphicsLevel++;
            if (graphicsLevel >= 3)
            {
                graphicsLevel = 0;
            }

            PlayerPrefs.SetInt("GraphicsSetting", graphicsLevel);
            PlayerPrefs.Save();
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("GraphicsSetting", 2), true);
            UpdateText();
        }

        void UpdateText()
        {
            switch (graphicsLevel)
            {
                case 0:
                default:
                    text.text = "Low";
                    break;
                case 1:
                    text.text = "Medium";
                    break;
                case 2:
                    text.text = "High";
                    break;
            }
        }
    }
}
