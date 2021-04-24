using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

/*

    LD48 Game Reference

    TO USE THIS IN YOUR SCRIPTS, COPY THE FOLLOWING CODE:    GameReference.Assign(ref gameRef);
    Requires a GameReference variable named gameRef (in this case), and the script must use the com.novega.ludumdare48 namespace.

*/

namespace com.novega.ludumdare48
{
    // This is where you'll put everything that the game needs to be able to access.
    // Examples: Player Inventory, UI Controllers, Save Systems.
    [System.Serializable]
    public class GameReference : MonoBehaviour
    {
        public static GameReference thisObject;
        [HideInInspector] public LDFEScript_EN dialogueScript; // the current script in the game; all other scripts derive from LampchasersDialogue_EN.
        [SerializeField] AudioMixer gameMixer;

        public bool bareMinimum = false;

        [Header("References")]
        [Tooltip("0 = EN, 1 = ES-MX, 2 = FR, 3 = IT, 4 = DE, 5 = JP, 6 = KR")]
        public int currentLanguage = 0;
        public CharacterMovement player;

        [Header("Enabled/Disabled")]
        public bool gameStarted;

        [SerializeField] float lerpSpeed;

        void Start() 
        {
            thisObject = this;

            // initialize dialogue
            var gObject = GameObject.FindWithTag("DialogueController");
            if (null == gObject)
            {
                dialogueScript = new GameObject().AddComponent<LDFEScript_EN>();
                dialogueScript.gameObject.name = "DialogueController";
                dialogueScript.gameObject.tag = "DialogueController";
            }
            else
            {
                dialogueScript = gObject.GetComponent<LDFEScript_EN>();
            }

            // initialize volume
            if (PlayerPrefs.HasKey("Music_VOL"))
            {
                gameMixer.SetFloat("Music", PlayerPrefs.GetFloat("Music_VOL"));
            }
            if (PlayerPrefs.HasKey("SFX_VOL"))
            {
                gameMixer.SetFloat("SFX", PlayerPrefs.GetFloat("SFX_VOL"));
            }

            // initialize graphics
            if (PlayerPrefs.HasKey("GraphicsSetting"))
            {
                QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("GraphicsSetting", 2), true);
            }
            else
            {
                QualitySettings.SetQualityLevel(2, true); // high by default
                PlayerPrefs.SetInt("GraphicsSetting", 2);
            }
        }

        void LateUpdate() {
            if (!bareMinimum) {
                // update game stuff
            }
        }

        public static void Assign(ref GameReference refObject) {
            if (null != thisObject) {
                refObject = thisObject;
            }
        }
    }
}
