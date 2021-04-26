using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.novega.ludumdare48
{
    public class UIS_SanityIndicator : MonoBehaviour
    {
        [SerializeField] Sprite[] sprites;
        [SerializeField] Image indicator;
        [SerializeField] CharacterMovement player;

        // Update is called once per frame
        void Update()
        {
            if (player.sanity >= 75f)
            {
                // 100% indicator
                indicator.sprite = sprites[3];
            }
            else if (player.sanity >= 50f)
            {
                // 75% indicator
                indicator.sprite = sprites[2];
            }
            else if (player.sanity >= 25f)
            {
                // 50% indicator
                indicator.sprite = sprites[1];
            }
            else
            {
                // 25% indicator
                indicator.sprite = sprites[0];
            }
        }
    }
}
