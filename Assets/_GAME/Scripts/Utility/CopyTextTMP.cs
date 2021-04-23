using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace com.novega.projectLIYAVERSE {
    public class CopyTextTMP : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI textToCopy;
        TextMeshProUGUI thisText;

        void Start()
        {
            thisText = GetComponent<TextMeshProUGUI>();
            thisText.text = textToCopy.text;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            thisText.text = textToCopy.text;
        }
    }
}
