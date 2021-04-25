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
            /* [00002]*/
            characterCast.Add("Ally");
        }

        public virtual void DefineScript()
        {
            /* [00000]*/
            characterScript.Add("/s/NULL:/e/ \nNULL");

            // SCENE: Test Script ---------------------------------------------------------------------------------------------------------------------------
            // [00001]
            characterScript.Add("/s/MOT:/e/ \nThis is a /i/test script/ei/. It'll be used for tests.");
            // [00002]
            characterScript.Add("/s/ANGIE:/e/ \nTo get to this scene, just set the DDS_Autoplay script's dialogue array to 0-1/skip/!");
            // [00003]
            characterScript.Add("(They aren't actually talking. It's kind of...creepy.)");

            // [00004]
            characterScript.Add("...");

            // SCENE: Monologue 001 ---------------------------------------------------------------------------------------------------------------------------
            // [00005]
            characterScript.Add("so this is like,");
            // [00006]
            characterScript.Add("it, I guess.");
            // [00007]
            characterScript.Add("my hands feel solid...");
            // [00008]
            characterScript.Add("...like oatmeal.");
            // [00009]
            characterScript.Add("my eyes feel...red.");
            // [00010]
            characterScript.Add("i've tripped over three different cracks in the sidewalks like, 3 times now.");
            // [00004] -----------------------------------------------------------------------------------------------
            // "..." -------------------------------------------------------------------------------------------------
            // [00011]
            characterScript.Add("is this what death feels like?");
            // [00012]
            characterScript.Add("i'm, like...");
            // [00013]
            characterScript.Add("...lacking corporeal form bro.");
            // [00004] -----------------------------------------------------------------------------------------------
            // "..." -------------------------------------------------------------------------------------------------
            // [00014]
            characterScript.Add("then again I did just get like, stabbed in the shoulder with, like, a syringe.");
            // [00015]
            characterScript.Add("maybe that had something to do with it.");
            // [00004] -----------------------------------------------------------------------------------------------
            // "..." -------------------------------------------------------------------------------------------------
            // [00016]
            characterScript.Add("yeah wait, what the fuck? i can still hear this asshole calling my name.");
            // [00017]
            characterScript.Add("can dead people like, hear the living?");
            // [00004] -----------------------------------------------------------------------------------------------
            // "..." -------------------------------------------------------------------------------------------------
            // [00018]
            characterScript.Add("wait.");
            // [00019]
            characterScript.Add("(Rico opens his eyes.)");
            // [00020]
            characterScript.Add("fuck.");

            // SCENE: Level 2 ---------------------------------------------------------------------------------------------------------------------------
            // [00021]
            characterScript.Add("/s/HANS:/e/ \nRICO? RICO MY GOOD SIR, CAN YOU HEAR ME?");
            // [00022]
            characterScript.Add("/s/RICO:/e/ \nwheuh ?????");
            // [00023]
            characterScript.Add("/s/RICO:/e/ \n...");
            // [00024]
            characterScript.Add("/s/RICO:/e/ \noh, yeah. wuzzup.");
            // [00025]
            characterScript.Add("/s/HANS:/e/ \nGood. Welcome to Science Lab Industrial Incorporated Industries, or in other words, SLIII.");
            // [00026]
            characterScript.Add("/s/RICO:/e/ \n...i don't know where we're at right now but this place kinda looks like an insane asylum /skip/.");
            // [00027]
            characterScript.Add("/s/HANS:/e/ \nNo.");
            // [00028]
            characterScript.Add("/s/HANS:/e/ \n...No. I have a PHD, this is totally cerified.");
            // [00029]
            characterScript.Add("/s/RICO:/e/ \na PHD is just a meaningless piece of paper brah.");
            // [00030]
            characterScript.Add("/s/RICO:/e/ \nwhat the fuck is /i/''SLIII''/ei/ anyways? you still haven’t told me yet.");
            // [00031]
            characterScript.Add("/s/HANS:/e/ \nDon't you, ''like'', /i/work here/ei/, ''dude''? You should know this stuff by now."); // imitating Rico
            // [00032]
            characterScript.Add("/s/RICO:/e/ \nokay, brah i know i'm wasted as fuck right now but i swear i'm not a dumbass.");
            // [00033]
            characterScript.Add("/s/RICO:/e/ \ndidn't we like, meet in a dark alleyway when i shook your hand for the first time after which you stabbed me with a syringe and i proceeded to pass out");
            // [00034]
            characterScript.Add("/s/DELLA:/e/ \nHEY, THAT WAS A TOTALLY VALID AND JUSTIFIED METHOD OF ACTION!");
            // [00035]
            characterScript.Add("/s/RICO:/e/ \nyea ok, you right.");
            // [00036]
            characterScript.Add("/s/RICO:/e/ \n...wait who's the chick");
            // [00037]
            characterScript.Add("/s/DELLA:/e/ \nDella Vasquez, Reporting For Call Of Duty! /click/I'm Here To Assist You And Mr. Reuter, In An Assistant - Like Fashion.");
            // [00038]
            characterScript.Add("/s/RICO:/e/ \noooookay. well, i have a few questions.");
            // [00039]
            characterScript.Add("/s/RICO:/e/ \nfirst of all, why are you making me do parkour?");
            // [00040]
            characterScript.Add("/s/RICO:/e/ \nand what the hell did you give me to make any of these jumps possible");
            // [00041]
            characterScript.Add("/s/HANS:/e/ \nWell, looks like we're out of time for questions today. Good luck.");
            // [00042]
            characterScript.Add("/s/RICO:/e/ \nwhat? no- /skip/!");
            // [00043]
            characterScript.Add("(Hans hangs up the phone.)");
            // [00044]
            characterScript.Add("/s/RICO:/e/ \nson of a bitch.");

            // SCENE: Level 1 ---------------------------------------------------------------------------------------------------------------------------
            // [00045]
            characterScript.Add("/s/HANS:/e/ \nRICO? RIC/i/~bzzt~/ei/, CA/i/~bzzt~/ei/AR ME? /i/~bzzt~/ei/");
            // [00046]
            characterScript.Add("/s/RICO:/e/ \n...?");
            // [00047]
            characterScript.Add("(Someone appears to be calling you, Rico Guzman, from a mysterious walkie-talkie holstered on your hip.)");
            // [00048]
            characterScript.Add("(It seems like they're having trouble reaching you.)");
            // [00049]
            characterScript.Add("/s/RICO:/e/ \nwhere even am i?");
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
