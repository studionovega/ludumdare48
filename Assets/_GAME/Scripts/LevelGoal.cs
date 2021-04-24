using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.novega.ludumdare48
{
    public class LevelGoal : MonoBehaviour
    {
        public string nextScene;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name.Contains("Player"))
            {
                StartCoroutine(EndLevel());
            }
        }

        private IEnumerator EndLevel()
        {
            CharacterMovement.freezeMovement = true;
            yield return new WaitForSeconds(4);
            SceneManager.LoadScene(nextScene);
        }
    }
}
