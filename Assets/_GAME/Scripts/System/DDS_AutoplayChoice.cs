using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Doublsb.Dialog;
using TMPro;

namespace com.novega.ludumdare48
{
    public class DDS_AutoplayChoice : MonoBehaviour
    {
        // WARNING: This is probably one of the least readable pieces of code you will ever see in this entire project, I know, ye have been warned.
        // If you want something to be changed / fixed, talk to me about it. Otherwise, good luck- keep a backup of the original. ~ Marten

        [Header("Choices")]
            [SerializeField] bool isUnskippable;
            [Tooltip("Refer to LampchasersDialogue_EN for these; works the same as dialogue and dialogueCharacterOrder.")]
            [SerializeField] int dialogueQuestion;
            [SerializeField] int dialogueQuestionCharacter;
            [Tooltip("Refer to LampchasersDialogue_EN for these; works the same as dialogue, dialogueQuestion and dialogueQuestionCharacter.")]
            [SerializeField] int[] dialogueChoices;
            [SerializeField] float waitSeconds = 2.0f;
            [SerializeField] GameObject[] dialogueResponses;
            [SerializeField] GameObject buttonTemplate, buttonHolder;

        GameReference gameRef;
        LDFEScript_EN dScript;
        DialogManager dialogManager;
        List<Button> buttons;
        bool choicesShown = false;
        float currentSeconds;

        // Start is called before the first frame update
        void Start()
        {
            // initialize variables
            GameReference.Assign(ref gameRef);
            dialogManager = GetComponent<DialogManager>();
            CharacterMovement.freezeMovement = true;
            dScript = gameRef.dialogueScript;

            var dData = new DialogData(dScript.characterScript[dialogueQuestion] + "/click/", dScript.characterCast[dialogueQuestionCharacter], null, isUnskippable ? false : true);

            // play the dialogue sequence
            dialogManager.Show(dData);

            currentSeconds = waitSeconds;
            StartCoroutine(ChoicesTimer());
        }

        void Update()
        {
            if (Input.GetButtonDown("ButtonA") && !choicesShown && !isUnskippable)
            {
                dialogManager.Set_Speed("0");
                StopCoroutine(ChoicesTimer());
                currentSeconds = 0.25f; // <- restart timer, but still give player time to react
                StartCoroutine(ChoicesTimer());
            }
        }

        IEnumerator ChoicesTimer()
        {
            yield return new WaitForSecondsRealtime(currentSeconds);

            // check because you're allowed to interrupt this timer if you skip
            if (choicesShown == false) {
                ShowChoices();
            }
        }

        void ShowChoices()
        {
            choicesShown = true;

            buttons = new List<Button>();

            // loop through every choice in the dialogue set; add them all as choices
            for (int i = 0; i <= dialogueChoices.Length - 1; i++) {
                Button j = Instantiate(buttonTemplate, buttonHolder.transform).GetComponent<Button>();
                j.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = dScript.characterScript[dialogueChoices[i]];
                j.onClick.AddListener(() => EvaluateChoices());
                buttons.Add(j);


                if (i == 0 && Input.GetJoystickNames().Length > 0) {
                    j.Select();
                }
            }
        }

        void FinishDialogue()
        {
            Destroy(this.gameObject);
        }

        public void EvaluateChoices()
        {
            int choice = 0;

            // since the choice names are just numbers converted into a string, we can parse the string to get a result.
            for (int i = 0; i <= buttons.Count - 1; i++) {
                if (buttons[i].gameObject == EventSystem.current.currentSelectedGameObject) {
                    choice = i;
                }
            }

            // take that result, and instantiate the corresponding index in the dialogueResponses array to start the dialogue for the next choice.
            Instantiate(dialogueResponses[choice]);

            // destroy the current dialogue object.
            FinishDialogue();
        }
    }
}
