using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace com.novega.projectLIYAVERSE {
    public class UIS_TextSwitchGamepad : MonoBehaviour
    {
        [SerializeField] string keyboardText, gamepadText;
        TextMeshProUGUI textComponent;

        // Start is called before the first frame update
        void Start()
        {
            textComponent = GetComponent<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetJoystickNames().Length > 0) {
                textComponent.text = gamepadText;
            }
            else {
                textComponent.text = keyboardText;
            }
        }
    }
}
