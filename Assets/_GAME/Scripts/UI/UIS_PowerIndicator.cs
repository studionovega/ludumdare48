using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.novega.ludumdare48
{
    public class UIS_PowerIndicator : MonoBehaviour
    {
        [SerializeField] CharacterMovement player;
        [SerializeField] Sprite noneSprite, controlFlipSprite, bunnyHopSprite, drunkModeSprite, tunnelVisionSprite;

        Image powerImage;

        private void Start()
        {
            powerImage = GetComponent<Image>();
        }

        // Update is called once per frame
        void Update()
        {
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

            if (player.tunnelVision)
            {
                powerImage.sprite = tunnelVisionSprite;
            }

            if (!player.controlFlip && !player.bunnyHop && !player.drunkMode && !player.tunnelVision)
            {
                powerImage.sprite = noneSprite;
            }
        }
    }
}
