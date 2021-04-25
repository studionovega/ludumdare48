using UnityEngine;
using System.Collections;


namespace com.novega.ludumdare48
{
    public class RayShooter : MonoBehaviour
    {
        private Camera _camera;
        //public GameObject hitPrefab;
        public GameObject cursorObject;
        public GameObject crosshairObject;
        public float maxDistance = 5f;
        //public float firingSpeed = 0.5f;

        // Use this for initialization
        void Start()
        {

            _camera = GetComponent<Camera>();
        }


        // Update is called once per frame
        void Update()
        {
            cursorObject.SetActive(false);
            crosshairObject.SetActive(true);
            
                Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
                Ray ray = _camera.ScreenPointToRay(point);
            
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, maxDistance))
                {
                    GameObject hitObject = hit.transform.gameObject;

                    Vector3 pos = hit.point;

                    //Debug.Log("You hit " + hit.transform.gameObject.ToString());

                    ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    cursorObject.SetActive(true);
                    crosshairObject.SetActive(false);
                    if (Input.GetMouseButtonDown(0))
                    {
                        target.ReactToHit();
                    }
                }
            }
        }


        private static IEnumerator SphereIndicator(Vector3 pos)//Creates a hit indicator and returns an IEnumerator
        {
            //Initialize a sphere
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = pos;
            //return the IEnumerator with the amount of time for the sphere to last
            yield return new WaitForSeconds(0.5f);
            //Remove the sphere after the wait time (code jumps back to this point somehow)
            // I don't actually understand it entirely. HURRAY FOR GAME ENGINES.
            Destroy(sphere);
        }

        private static IEnumerator HitEffect(Vector3 pos, GameObject prefab)//Creates a hit indicator and returns an IEnumerator
        {
            //Initialize a particle effect prefab
            GameObject sparks = (GameObject)Instantiate(prefab, pos, Quaternion.identity);
            //return the IEnumerator with the amount of time for the sphere to last
            yield return new WaitForSeconds(0.5f);
            //Remove the effect after the wait time
            Destroy(sparks);
        }


    }
}