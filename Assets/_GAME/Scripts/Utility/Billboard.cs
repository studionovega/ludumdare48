using UnityEngine;

namespace com.novega.projectLIYAVERSE {
    public class Billboard : MonoBehaviour
    {
        public bool vector3UpNegation = false;

        void Update()
        {
            transform.LookAt(Camera.main.transform.position, vector3UpNegation ? -Vector3.up : Vector3.up);
        }
    }
}
