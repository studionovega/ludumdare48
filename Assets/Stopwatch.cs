using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.novega.ludumdare48
{
    public class Stopwatch : MonoBehaviour
    {
        public bool runTimer;
        public float levelTime = 0f;
        private float countdownTime = 3;
        public Text timerText;
        public GameObject timerTextObject;
        public Text countdownText;
        public GameObject countdownTextObject;
        public GameReference gameRef;

        // Start is called before the first frame update
        void Start()
        {
            StartCountdown();
        }

        // Update is called once per frame
        void Update()
        {
        if (runTimer)
            {
                levelTime += Time.deltaTime;
                timerText.text = levelTime.ToString("0.000");
            }
            else
            {
                countdownTime -= Time.deltaTime;
                countdownText.text = Mathf.Ceil(countdownTime).ToString();
            }
        }

        void StartCountdown()
        {
            Debug.Log("Help me");
            StartCoroutine(CountdownTimer());
        }

        private IEnumerator CountdownTimer()
        {
            Debug.Log("Start countdown");
            countdownTime = 3f;
            levelTime = 0f;
            runTimer = false;
            timerTextObject.SetActive(false);
            countdownTextObject.SetActive(true);
            CharacterMovement.freezeMovement = true;

            yield return new WaitForSeconds(3);

            countdownTextObject.SetActive(false);
            timerTextObject.SetActive(true);
            CharacterMovement.freezeMovement = false;
            runTimer = true;
            Debug.Log("Finished countdown");
        }
    }
}
