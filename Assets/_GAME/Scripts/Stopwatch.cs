using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace com.novega.ludumdare48
{
    public class Stopwatch : MonoBehaviour
    {
        public bool runTimer;
        public float levelTime = 0f;
        private float countdownTime = 6;
        public TextMeshProUGUI timerText;
        public GameObject timerTextObject;
        public TextMeshProUGUI countdownText;
        public GameObject countdownTextObject;
        public GameReference gameRef;

        // Start is called before the first frame update
        void Start()
        {
            GameReference.Assign(ref gameRef);

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
                countdownTime -= Time.deltaTime * 2f;
                countdownText.text = Mathf.Ceil(countdownTime / 2f).ToString();
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
            countdownTime = 6f;
            levelTime = 0f;
            runTimer = false;
            timerTextObject.SetActive(false);
            countdownTextObject.SetActive(true);
            gameRef.gameStarted = false;

            MusicManager.self.PauseMusic();

            yield return new WaitForSeconds(countdownTime / 2f);

            countdownTextObject.SetActive(false);
            timerTextObject.SetActive(true);
            gameRef.gameStarted = true;
            CharacterMovement.freezeMovement = false;
            runTimer = true;
            MusicManager.self.PlayMusic(MusicManager.self.spoomk);
            Debug.Log("Finished countdown");
        }
    }
}
