using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace com.novega.projectLIYAVERSE {
    public class CommandPrompt : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI input;
        [SerializeField] GameObject logTextPrefab;

        GameObject log;
        string command;

        // Start is called before the first frame update
        void Start()
        {
            log = GameObject.Find("CommandLog");
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return)) {
                string[] results = input.text.Split('?');

                string output;
                if (results.Length > 0) {
                    output = results[0];
                } else {
                    output = input.text;
                }

                switch (output)
                {
                    case "spawn":
                        if (results.Length < 2) {
                            LogResults("error: not enough arguments for command 'spawn'");
                        } else {
                            switch(results.Length) {
                                case 5:
                                    SpawnObject(results[1],
                                        new Vector3(float.Parse(results[2]), float.Parse(results[3]), float.Parse(results[4])),
                                        Vector3.zero);
                                    break;
                                case 8:
                                    SpawnObject(results[1],
                                        new Vector3(float.Parse(results[2]), float.Parse(results[3]), float.Parse(results[4])),
                                        new Vector3(float.Parse(results[5]), float.Parse(results[6]), float.Parse(results[7])));
                                    break;
                                default:
                                    SpawnObject(results[1], Vector3.zero, Vector3.zero);
                                    break;
                            }
                        }
                        break;

                    default:
                        LogResults("unknown command");
                        break;
                }
            }
        }

        void SpawnObject(string o, Vector3 position, Vector3 rotation)
        {
            GameObject r = Instantiate(Resources.Load("spawnables/" + o, typeof(GameObject)), Vector3.zero, Quaternion.identity) as GameObject;

            if (null != position) {
                r.transform.position = position;
            }

            if (null != rotation) {
                r.transform.rotation = Quaternion.Euler(rotation);
            }

            LogResults($"spawned {o} at POSIITON:{r.transform.position}, ROTATION:{r.transform.rotation}");
        }

        void LogResults(string r)
        {
            TextMeshProUGUI rText = Instantiate(logTextPrefab, log.transform).GetComponentInChildren<TextMeshProUGUI>();
            rText.text = r;

            Destroy(this.gameObject);
        }

        public void UpdateCommand()
        {
            command = input.text;
        }
    }
}
