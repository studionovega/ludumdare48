using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.ludumdare48
{
    public class PlatformReactor : MonoBehaviour
    {
        SplineInterpolator _spline;

        private void Start()
        {
            _spline = GetComponent<SplineInterpolator>();
        }

        public void React()
        {
            if (_spline.mState == "Loop")
            {

                _spline.mState = "Reset";
            }
            else
            {
                _spline.mState = "Loop";
            }
        }
    }
}
