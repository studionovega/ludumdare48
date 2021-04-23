using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.novega.projectLIYAVERSE {
    public class UIS_GamepadSwitch : MonoBehaviour
    {
        public bool dualshockMode;
        public Sprite KBMIcon, xboxIcon, dualshockIcon;

        Image currentIcon;

        void Start() {
            currentIcon = GetComponent<Image>();
        }

        // Update is called once per frame
        void LateUpdate()
        {
            if (Input.GetJoystickNames().Length > 0) {
                if (dualshockMode) {
                    currentIcon.sprite = dualshockIcon;
                } else {
                    currentIcon.sprite = xboxIcon;
                }
            } else {
                currentIcon.sprite = KBMIcon;
            }
        }
    }
}
