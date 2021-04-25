using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

namespace com.novega.ludumdare48
{
    public class DDS_Autoplay : MonoBehaviour
    {
        // WARNING: This is probably one of the least readable pieces of code you will ever see in this entire project, I know, ye have been warned.
        // If you want something to be changed / fixed, talk to me about it. Otherwise, good luck- keep a backup of the original. ~ Marten

        [SerializeField] bool autoSkip = false;
        [SerializeField] float autoSkipInterval = 5f;
        [SerializeField] bool startAfterSeconds = false;
        [SerializeField] float seconds;
        [SerializeField] bool freezePlayer = false;

        [Header("Dialogue")]
            [Tooltip("The actual dialogue spoken in this object. Refer to LDFEScript_EN for your line numbers.")]
            [SerializeField] int[] dialogue;
            [Tooltip("Keeps track of who's saying what in this object. Refer to LDFEScript_EN for your character cast and their respective integers. This is required; and it must line up with the dialogue's array numbers, or else it will not display in the right order.")]
            [SerializeField] int[] dialogueCharacterOrder;
            [Tooltip("If you want a character to perform an action, then you have to make a separate script that will execute automatically once its GameObject is created (in the Start method). To allow for these actions mid-conversation, you can make a new dialogue GameObject and assign it here to continue the conversation.")]
            [SerializeField] GameObject nextDialogue;

        [Header("Settings")]
            [Tooltip("If you want a piece of the dialogue to be unskippable, specify the specific index numbers here. For example: to make the first line in this dialogue object unskippable, add an integer to this array with the value 0.")]
            [SerializeField] int[] unskippableDialogueEntries;
            [SerializeField] bool hasCallback;

        // to be used by other scripts inside of the same dialogue object to know when it's finished
        [HideInInspector] public bool _eventTrigger;

        GameReference gameRef;
        LDFEScript_EN dScript;
        DialogManager dialogManager;
        float skipTime;

        // Start is called before the first frame update
        IEnumerator Start()
        {
            yield return null;

            if (startAfterSeconds) {
                yield return new WaitForSecondsRealtime(seconds);
            }

            // initialize variables
            GameReference.Assign(ref gameRef);
            dialogManager = GetComponent<DialogManager>();
            CharacterMovement.freezeMovement = freezePlayer;
            dScript = gameRef.dialogueScript;
            var dData = new List<DialogData>();

            if (dialogue.Length > 0) {
                for (int d = 0; d <= dialogue.Length - 1; d++) {
                    // initialize unskippable bool; if this entry isn't unskippable then this will remain false
                    bool unskippable = false;

                    // set unskippable to true if this for loop finds an equivalent integer inside of unskippableDialogueEntries
                    for (int u = 0; u <= unskippableDialogueEntries.Length - 1; u++) {
                        if (d == u) {
                            unskippable = true;
                        }
                    }

                    // if not the final entry in the dialogue, add it to the dialogue data.
                    if (d != dialogue.Length - 1) {
                        dData.Add(new DialogData(dScript.characterScript[dialogue[d]], dScript.characterCast[dialogueCharacterOrder[d]], null, unskippable ? false : true));
                    } else {
                        if (hasCallback) {
                            dData.Add(new DialogData(dScript.characterScript[dialogue[d]], dScript.characterCast[dialogueCharacterOrder[d]], () => SetTrigger(), unskippable ? false : true));
                        } else {
                            // no callbacks, no choices, just destroy the dialogue right away.
                            dData.Add(new DialogData(dScript.characterScript[dialogue[d]], dScript.characterCast[dialogueCharacterOrder[d]], () => FinishDialogue(), unskippable ? false : true));
                        }
                    }
                }
            } else {
                // show dialogue error if there's no dialogue data
                dData.Add(new DialogData(
                "SYSTEM: \n/color:red/An error has occurred in the LAMPCHASERS dialogue system (x01-DNYD). /color:white/If you are seeing this message, then please report this error to us at /color:yellow/info@studionove.ga/color:white/ with the location where it happened- as it is likely a bug.",
                "System", null, false));
            }

            // play the dialogue sequence
            dialogManager.Show(dData);
        }

        void Update()
        {
            string button = "ButtonA";
            if (!freezePlayer)
            {
                button = "ButtonX";
            }

            if (autoSkip)
            {
                skipTime += Time.deltaTime;
            }

            if (Input.GetButtonDown(button) || skipTime >= autoSkipInterval) {
                dialogManager.Click_Window();
                skipTime = 0f;
            }
        }

        void FinishDialogue()
        {
            if (null != nextDialogue) {
                Instantiate(nextDialogue, transform.position, Quaternion.identity);
            }

            CharacterMovement.freezeMovement = false;
            Destroy(this.gameObject);
        }

        void SetTrigger()
        {
            _eventTrigger = true;
            Debug.LogWarning("DEV WARNING: Since a callback has been triggered, note that the dialogue GameObject will not be automatically destroyed by DDS_Autoplay. Don't forget to destroy it in the callback script after its finished setting what needs to be set!");
        }
    }
}
