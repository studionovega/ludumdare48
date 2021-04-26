using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.novega.ludumdare48
{
    public class UIS_PowerIndicator : MonoBehaviour
    {
        [SerializeField] CharacterMovement player;
        [SerializeField] Sprite noneSprite, controlFlipSprite, bunnyHopSprite, drunkModeSprite, hyperfocusSprite;

        Image powerImage;

        private void Start()
        {
            powerImage = GetComponent<Image>();
        }

        // Update is called once per frame
        void Update()
        {
            if (player.noPowers)
            {
                powerImage.sprite = noneSprite;
            }

            if (player.controlFlip)
            {
                powerImage.sprite = controlFlipSprite;
            }

            if (player.bunnyHop)
            {
                powerImage.sprite = bunnyHopSprite;
            }

            if (player.drunkMode)
            {
                powerImage.sprite = drunkModeSprite;
            }

            if (player.hyperfocus)
            {
                powerImage.sprite = hyperfocusSprite;
            }
        }
    }
}
