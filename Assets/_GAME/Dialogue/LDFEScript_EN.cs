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
            characterCast.Add("Ally"); // test character
            /* [00003]*/
            characterCast.Add("Rico");
            /* [00004]*/
            characterCast.Add("Della");
            /* [00005]*/
            characterCast.Add("Hans");
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
            characterScript.Add("fuck.");

            // [00004]
            characterScript.Add("...");

            // SCENE: Monologue 001 ---------------------------------------------------------------------------------------------------------------------------
            // [00005]
            characterScript.Add("so this is like,");
            // [00006]
            characterScript.Add("/speed:0.1/it,/wait:0.5//speed:0.05/ I guess.");
            // [00007]
            characterScript.Add("my hands feel solid...");
            // [00008]
            characterScript.Add("...like oatmeal.");
            // [00009]
            characterScript.Add("my eyes feel.../wait:0.5//i/red/ei/.");
            // [00010]
            characterScript.Add("i've tripped over three different cracks in the \nsidewalks like, three times now.");
            // [00004] -----------------------------------------------------------------------------------------------
            // "..." -------------------------------------------------------------------------------------------------
            // [00011]
            characterScript.Add("is this what death feels like?");
            // [00012]
            characterScript.Add("i'm, like...");
            // [00013]
            characterScript.Add("...lacking corporeal form, bro.");
            // [00004] -----------------------------------------------------------------------------------------------
            // "..." -------------------------------------------------------------------------------------------------
            // [00014]
            characterScript.Add("then again... /click/\nI did just get like, stabbed in the shoulder with a syringe.");
            // [00015]
            characterScript.Add("i do make some good points.");
            // [00004] -----------------------------------------------------------------------------------------------
            // "..." -------------------------------------------------------------------------------------------------
            // [00016]
            characterScript.Add("yeah wait, what the fuck? i just heard that \nasshole call my name again.");
            // [00017]
            characterScript.Add("can dead people like, hear the living?");
            // [00004] -----------------------------------------------------------------------------------------------
            // "..." -------------------------------------------------------------------------------------------------
            // [00018]
            characterScript.Add("wait.");
            // [00019]
            characterScript.Add("(Rico opens his eyes.)");
            // [00020]
            characterScript.Add("oh.");

            // SCENE: Level 2 ---------------------------------------------------------------------------------------------------------------------------
            // [00021]
            characterScript.Add("/s/HANS:/e/ \nRICO? RICO MY GOOD SIR, CAN YOU \nHEAR ME?");
            // [00022]
            characterScript.Add("/s/RICO:/e/ \nwheuh ?????");
            // [00023]
            characterScript.Add("/s/RICO:/e/ \n...");
            // [00024]
            characterScript.Add("/s/RICO:/e/ \noh, yeah. wuzzup.");
            // [00025]
            characterScript.Add("/s/HANS:/e/ \nGood. Welcome to Science Lab \nIndustrial Incorporated Industries, \nor in other words, SLIII.");
            // [00026]
            characterScript.Add("/s/RICO:/e/ \n...i don't know where we're at right \nnow but this place kinda looks like \nan insane asylum /skip/.");
            // [00027]
            characterScript.Add("/s/HANS:/e/ \nNo.");
            // [00028]
            characterScript.Add("/s/HANS:/e/ \n...No. I have a PHD, this is totally \ncerified.");
            // [00029]
            characterScript.Add("/s/RICO:/e/ \na PHD is just a meaningless piece of \npaper brah.");
            // [00030]
            characterScript.Add("/s/RICO:/e/ \nwhat the fuck is /i/''SLIII''/ei/ anyways? \nyou still haven't told me yet.");
            // [00031]
            characterScript.Add("/s/HANS:/e/ \nDon't you, ''like'', /i/work here/ei/, /speed:down/''dude''? /wait:0.25//speed:up/\nYou should know this stuff by now."); // imitating Rico
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
            characterScript.Add("/s/DELLA:/e/ \nDella Vasquez, Reporting For Call Of Duty! /click/I'm Here To Assist You And Mr. Reuter, In An Assistant-Like Fashion.");
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
            characterScript.Add("/s/HANS:/e/ \nRICO? RIC/i/~bzzt~/ei/, CA/i/~bzzt~/ei/AR ME? \n/i/~bzzt~/ei/");
            // [00046]
            characterScript.Add("/s/RICO:/e/ \n...?");
            // [00047]
            characterScript.Add("(A mysterious man appears to be \ncalling you, /i/(rico guzman)/ei/, from an \nequally mysterious walkie-talkie \nholstered on your hip.)");
            // [00048]
            characterScript.Add("(It seems like they're having trouble \nreaching you. They're screaming \ninto their microphone.)");
            // [00049]
            characterScript.Add("/s/RICO:/e/ \nwhere even am i?");

            // SCENE: Level 3 ---------------------------------------------------------------------------------------------------------------------------
            // [00050]
            characterScript.Add("/s/RICO:/e/ \nalright, I finished that stupid \npuzzle. you gonna tell me what you \njust stabbed me with now bro?");
            // [00051]
            characterScript.Add("/s/HANS:/e/ \n...");
            // [00052]
            characterScript.Add("/s/HANS:/e/ \nI don't know what you're talking \nabout.");
            // [00053]
            characterScript.Add("/s/DELLA:/e/ \nlol, That's Code For ''You \nFuckin' Wish''.");
            // [00054]
            characterScript.Add("/s/RICO:/e/ \nyou guys are unbelievable.");
            // [00055]
            characterScript.Add("/s/HANS:/e/ \nyou're the one who agreed to me \nstabbing you with a syringe.");
            // [00056]
            characterScript.Add("/s/RICO:/e/ \num, /i/sorry/ei/, can you /i/pinpoint/ei/ the \nmoment in time when i /i/agreed/ei/ to \nbeing stabbed with a fucking syringe?");
            // [00057]
            characterScript.Add("/s/HANS:/e/ \nYes, I can actually! It was the moment when I signed the contract with your finger after you passed out./wait:0.25//skip/.");
            // [00058]
            characterScript.Add("/s/RICO:/e/ \n/i/you wot m8/ei/?");
            // [00059]
            characterScript.Add("/s/HANS:/e/ \nHey, don't look a gift horse in the mouth \nkid. You can't afford a gram of anything \nelse and I stabbed you with that syringe \nfree of charge.");
            // [00060]
            characterScript.Add("/s/RICO:/e/ \n...");
            // [00061]
            characterScript.Add("(Rico lets out a sigh of pure, \nunadulterated self-disappointment.)");
            // [00062]
            characterScript.Add("/s/RICO:/e/ \nfine.");
            // [00063]
            characterScript.Add("(Rico makes a note to himself to \ndrive his hotboxing car into a lake \nafter he escapes.)");

            // SCENE: Level 4 ---------------------------------------------------------------------------------------------------------------------------
            // [00064]
            characterScript.Add("/s/DELLA:/e/ \nAlright, Mr. Rico. Hans Is Away From The Walkie-Talkies At The Moment, but Let Me Just Say...");
            // [00065]
            characterScript.Add("/s/DELLA:/e/ \nYou're Doing Pretty Well So Far. We Just Need To Run A Few More Tests, and We'll Be All Set To Let You Go!");
            // [00066]
            characterScript.Add("/s/RICO:/e/ \noh thank god. /wait:0.25/I mean-/skip/-");
            // [00067]
            characterScript.Add("/s/RICO:/e/ \nSounds Great!");
            // [00068]
            characterScript.Add("/s/DELLA:/e/ \nNah, I Get It. Hans Can Be Kind Of An Ass Sometimes.");
            // [00069] haha nice
            characterScript.Add("/s/DELLA:/e/ \nHere, I Know He Was Being Stubborn Earlier, and I Feel Like You Should At Least Know What The Hell He Stabbed You With.");
            // [00070]
            characterScript.Add("/s/DELLA:/e/ \nPretend I Said Nothing, But The Drug That You Were Injected With Is Called- /wait:0.5/in his words, not mine-/wait:0.5/ ''Methamphetamine 2, Electric Boogaloo''.");
            // [00071]
            characterScript.Add("/s/RICO:/e/ \nsounds like our friend is pretty great with names.");
            // [00072]
            characterScript.Add("/s/DELLA:/e/ \nThe Best.");
            // [00073]
            characterScript.Add("/s/DELLA:/e/ \nAnyways, Research Suggests That There Could Be A Possible Correlation Between Taking It.../wait:0.5/and Possessing Abnormally Large Genitalia.");
            // [00074]
            characterScript.Add("/s/DELLA:/e/ \nHe Just Didn't Want To Risk It Backfiring On Him, So He Hired You To Test It For Him.");
            // [00075]
            characterScript.Add("/s/RICO:/e/ \n.../click/huh.");
            // [00076]
            characterScript.Add("/s/RICO:/e/ \nwell, i suppose there's a bright side to this then.");
            // [00077]
            characterScript.Add("/s/DELLA:/e/ \n/i/Yeah/ei/, You Truly /i/Took One For The Team/ei/ With This One. Congrats On Somehow Getting Here Alive.");
            // [00078]
            characterScript.Add("/s/RICO:/e/ \nthank you, i'm glad to be making a contribution to society.");
            // [00079]
            characterScript.Add("/s/RICO:/e/ \nbut wait.../wait:0.25/if you're working for Hans, then why are you helping me out?");
            // [00080]
            characterScript.Add("/s/DELLA:/e/ \nWell, Don't Get Me Wrong- Hans Is A Surprisingly Good Boss.");
            // [00081]
            characterScript.Add("/s/RICO:/e/ \nemphasis on ''surprisingly''.");
            // [00082]
            characterScript.Add("/s/DELLA:/e/ \nBut He Can Also Be Stubborn Sometimes. When That Happens, It's My Turn To Step In.");
            // [00083]
            characterScript.Add("/s/DELLA:/e/ \nConsider It A Way To Tip The Scale Back.");
            // [00084]
            characterScript.Add("/s/RICO:/e/ \nwell.../wait:0.5/ thank you. /click/ i appreciate it.");
            // [00085]
            characterScript.Add("/s/DELLA:/e/ \nNo Problem. /click/Finish The Puzzle And Let's Get Going.");
            // [00086]
            characterScript.Add("/s/RICO:/e/ \naye aye, capt-ette.");
            // [00087]
            characterScript.Add("/s/DELLA:/e/ \nplease don't ever say that again.");
            // [00088]
            characterScript.Add("/s/RICO:/e/ \nsure.");
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
