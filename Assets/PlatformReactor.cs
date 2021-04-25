using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.ludumdare48
{
    public class PlatformReactor : MonoBehaviour
    {
        SplineInterpolator _spline;
        SplineController _controller;

        private void Start()
        {
            _spline = GetComponent<SplineInterpolator>();
            _controller = GetComponent<SplineController>();
        }

        public void React()
        {
            if (!_controller.AutoStart)
            {
                _controller.FollowSpline();
                _controller.AutoStart = true;
                return;
            }
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
