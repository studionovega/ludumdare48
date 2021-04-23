using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

namespace com.novega.projectLIYAVERSE
{
    public class DoTween : MonoBehaviour
    {
        public bool startTween = true;
        public string type;
        public bool activateAfterWait = true;
        public float waitSeconds = 0f;
        public float seconds = 1f;
        public float backupLerp = 0.25f;
        public float toFloat = 0f;
        public Color toColor = Color.white;

        private Image image;
        private TextMeshProUGUI text;
        private AudioSource audioSource;
        private RectTransform rect;
        private Camera cam;

        IEnumerator Start()
        {
            // Looks for components at start to avoid constantly defining it in Update. Based on defined Type.
            switch (type) {
                case "ImageAlpha":
                case "ImageColor":
                    image = GetComponent<Image>();
                    break;
                case "TextAlpha":
                    text = GetComponent<TextMeshProUGUI>();
                    break;
                case "AudioVolume":
                case "AudioVolumeLerp":
                    audioSource = GetComponent<AudioSource>();
                    break;
                case "BottomRect":
                case "UIYPosition":
                    rect = GetComponent<RectTransform>();
                    break;
                case "CameraFOV":
                    cam = GetComponent<Camera>();
                    break;
                default:
                    break;
            }

            yield return new WaitForSecondsRealtime(waitSeconds);

            if (activateAfterWait) {
                startTween = true;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (startTween && gameObject.activeInHierarchy)
            {
                switch (type)
                {
                    case "ImageAlpha":
                        image.DOFade(toFloat, seconds);
                        break;
                    case "ImageColor":
                        image.DOColor(toColor, seconds);
                        break;
                    case "TextAlpha":
                        // TextMeshPro tweening is only available in DOTween PRO. So, in its place, a Lerp will be used.
                        text.color = Color.Lerp(text.color, toColor, backupLerp);
                        break;
                    case "AudioVolume":
                        audioSource.DOFade(toFloat, seconds);
                        break;
                    case "AudioVolumeLerp":
                        audioSource.volume = Mathf.Lerp(audioSource.volume, toFloat, backupLerp);
                        break;
                    case "BottomRect":
                        // Mainly used for main menu tweening.
                        rect.offsetMin = new Vector2(rect.offsetMin.x, Mathf.Lerp(rect.offsetMin.y, toFloat, backupLerp));
                        break;
                    case "UIYPosition":
                        // Mainly used for main menu tweening.
                        rect.DOAnchorPosY(toFloat, seconds);
                        break;
                    case "Scale":
                        transform.DOScale(toFloat, seconds);
                        break;
                    case "CameraFOV":
                        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, toFloat, backupLerp);
                        break;
                    default:
                        break;
                }
            }
        }

        public void SetColor(Color _color)
        {
            toColor = _color;
        }

        public void SetFloat(float _float)
        {
            toFloat = _float;
        }

        public void SetSeconds(float _seconds)
        {
            seconds = _seconds;
        }

        public void SetLerp(float _lerp)
        {
            backupLerp = _lerp;
        }
    }
}
