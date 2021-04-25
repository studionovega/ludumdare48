using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.novega.ludumdare48
{
    public class UIS_LoadScene : MonoBehaviour
    {
        public string sceneToLoad;
        public bool loadThisScene = false;
        public bool loadAutomatically;
        public float waitSeconds;
        AsyncOperation op;
        bool sceneLoading = false;

        // Start is called before the first frame update
        void Start()
        {
            DontDestroyOnLoad(gameObject);
            if (loadAutomatically)
            {
                StartCoroutine(SceneLoad());
            }
        }

        public void StartLoad()
        {
            if (!sceneLoading)
            {
                StartCoroutine(SceneLoad());
            }
        }

        // Update is called once per frame
        IEnumerator SceneLoad()
        {
            sceneLoading = true;

            if (loadThisScene)
            {
                sceneToLoad = SceneManager.GetActiveScene().name;
            }

            op = SceneManager.LoadSceneAsync(sceneToLoad);
            op.allowSceneActivation = false;

            yield return new WaitForSecondsRealtime(0.5f); // wait 0.5s

            yield return new WaitForSecondsRealtime(waitSeconds); // wait for WaitSeconds time

            yield return op.isDone; // wait until scene is finished loading

            op.allowSceneActivation = true; // load in the scene
            yield return new WaitForSecondsRealtime(0.5f); // wait an extra 0.5s

            Destroy(this.gameObject); // finish
        }
    }
}
