using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.projectLIYAVERSE {
    public class BS_GoBack : MonoBehaviour
    {
        public GameObject objectToDisable;
        public GameObject objectToReactivate;
        public GameObject instantiateOnExit;
        public GameObject destroyObject;
        public string cancelButton = "Cancel";

        void Update() {
            if (!string.IsNullOrEmpty(cancelButton))
            {
                if (Input.GetButtonDown(cancelButton))
                {
                    GoBack();
                }
            }
        }

        public void GoBack() {
            if (objectToDisable) {
                // disable this object
                objectToDisable.SetActive(false);
            }

            if (objectToReactivate) {
                // enable the object to reactivate
                objectToReactivate.SetActive(true);
            }

            if (null != instantiateOnExit)
            {
                Instantiate(instantiateOnExit, transform.position, Quaternion.identity);
            }

            if (destroyObject)
            {
                Destroy(destroyObject);
            }
        }
    }
}
