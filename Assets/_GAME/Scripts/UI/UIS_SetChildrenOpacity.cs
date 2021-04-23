using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace com.novega.projectLIYAVERSE {
    public class UIS_SetChildrenOpacity : MonoBehaviour
    {
        public float targetOpacity;
        public float lerpSpeed;

        [SerializeField] float currentOpacity;
        [SerializeField] TextMeshProUGUI[] textFields;
        [SerializeField] Image[] sprites;

        void Update() {
            UpdateOpacity(Mathf.Lerp(currentOpacity, targetOpacity, lerpSpeed));
        }

        public void UpdateOpacity(float opacity)
        {
            foreach(TextMeshProUGUI textField in textFields) {
                textField.alpha = opacity;
            }

            foreach(Image sprite in sprites) {
                sprite.color = new Color(1.0f, 1.0f, 1.0f, opacity);
            }

            currentOpacity = opacity;
        }
    }
}
