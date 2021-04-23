using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.projectLIYAVERSE
{
    public class AnyKeyToTween : MonoBehaviour
    {
        public DoTween tween;
        public bool activateThisTween;
        public Color thisToColor;
        public float thisToFloat;

        // Update is called once per frame
        void Update()
        {
            if (Input.anyKeyDown)
            {
                // Start the tween for the other object
                tween.gameObject.SetActive(true);
                tween.startTween = true;

                // If we want to tween away this object, and there's a tweening component attached,
                if (GetComponent<DoTween>() != null && activateThisTween)
                {
                    // Get the component and set the variables.
                    DoTween doTween = GetComponent<DoTween>();
                    doTween.startTween = true;
                    doTween.toColor = thisToColor;
                    doTween.toFloat = thisToFloat;
                }

                Destroy(gameObject, 0.5f);
            }
        }
    }
}