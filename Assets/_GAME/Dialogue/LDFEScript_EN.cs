using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.ludumdare48
{
    public class LDFEScript_EN : MonoBehaviour
    {
        [HideInInspector] public List<string> gameScript = new List<string>();
        [HideInInspector] public List<string> characterScript = new List<string>();
        [HideInInspector] public List<string> characterCast = new List<string>();

        void Start()
        {
            DefineUI();
            DefineCharacters();
            DefineScript();

            DontDestroyOnLoad(this.gameObject);
        }

        void DefineCharacters()
        {
            /* [00000]*/
            characterCast.Add("NULL");

            // NOTE: there is no "???" character in the dialogue system since the character's name in the UI isn't based off of the character's name.
            // This allows for character name gags, and it also allows for us to hide the name through the script itself.
            // NOTE NOTE: If you're using this for DDS_Autoplay, be weary. It will break the system if the specified Character doesn't exist as an object in the dialogue asset.

            /* [00001]*/
            characterCast.Add("System");
        }

        public virtual void DefineScript()
        {
            /* [00000]*/
            characterScript.Add("/s/NULL:/e/ \nNULL");

            // SCENE: Test Script ---------------------------------------------------------------------------------------------------------------------------
            /* [00001]*/
            characterScript.Add("/s/MOT:/e/ \nThis is a /i/test script/ei/. It'll be used for tests.");
            /* [00002]*/
            characterScript.Add("/s/ANGIE:/e/ \nTo get to this scene, just set the DDS_Autoplay script's dialogue array to 0-1/skip/!");
            /* [00003]*/
            characterScript.Add("(They aren't actually talking. It's kind of...creepy.)");
        }

        public virtual void DefineUI()
        {
            // SYSTEM: User Interface
            /* [00000]*/
            gameScript.Add("New Game");
            /* [00000]*/
            gameScript.Add("Load Game");
            /* [00000]*/
            gameScript.Add("Options");
            /* [00000]*/
            gameScript.Add("Quit");
            /* [00000]*/
            gameScript.Add("Select");
            /* [00000]*/
            gameScript.Add("Back");
            /* [00000]*/
            gameScript.Add("Save");
            /* [00000]*/
            gameScript.Add("Warning");
            /* [00000]*/
            gameScript.Add("Error");
            /* [00000]*/
            gameScript.Add("Info");
            /* [00000]*/
            gameScript.Add("This game uses an autosave feature.");
            /* [00000]*/
            gameScript.Add("Please do not quit or turn off your system while the following icon is being displayed.");
            /* [00000]*/
            gameScript.Add("An error has occurred, and the following save file cannot be read. Please exit the game, and contact Team LAMPCHASERS at info@studionove.ga for further assistance.");
            /* [00000]*/
            gameScript.Add("Credits");
            /* [00000]*/
            gameScript.Add("Inventory");
            /* [00000]*/
            gameScript.Add("Items");
            /* [00000]*/
            gameScript.Add("Time");
            /* [00000]*/
            gameScript.Add("Keep playing");
            /* [00000]*/
            gameScript.Add("Save and quit");
            /* [00000]*/
            gameScript.Add("Buy");
            /* [00000]*/
            gameScript.Add("Sell");
            /* [00000]*/
            gameScript.Add("Talk");
            /* [00000]*/
            gameScript.Add("Exit");
        }
    }
}
