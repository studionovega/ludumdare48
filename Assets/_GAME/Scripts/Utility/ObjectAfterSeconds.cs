using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.projectLIYAVERSE {
    public class ObjectAfterSeconds : MonoBehaviour
    {
        public enum EditType {
            Instantiate,
            Destroy
        }

        [SerializeField] EditType type = EditType.Destroy;
        [SerializeField] float seconds;
        [SerializeField] GameObject[] objects;

        // Start is called before the first frame update
        IEnumerator Start()
        {
            yield return new WaitForSecondsRealtime(seconds);

            if (objects.Length == 0 || null == objects)
            {
                switch (type) {
                    default:
                    case EditType.Destroy:
                        Destroy(this.gameObject);
                        break;
                }
            }
            else
            {
                switch (type) {
                    default:
                    case EditType.Destroy:
                        for (int i = 0; i <= objects.Length - 1; i++) {
                            Destroy(objects[i]);
                        }
                        break;
                    case EditType.Instantiate:
                        for (int i = 0; i <= objects.Length - 1; i++) {
                            Instantiate(objects[i], transform.position, Quaternion.identity);
                        }
                        break;
                }
                Destroy(this);
            }
        }
    }
}
