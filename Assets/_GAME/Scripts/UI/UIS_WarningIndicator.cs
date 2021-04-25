using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.novega.ludumdare48
{
    public class UIS_WarningIndicator : MonoBehaviour
    {
        GameReference gameRef;
        CharacterMovement player;
        Image warningImage;
        Vector3 startPosition;

        // Start is called before the first frame update
        void Start()
        {
            GameReference.Assign(ref gameRef);
            player = gameRef.player;
            warningImage = GetComponent<Image>();
            startPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log(gameRef);

            if (player != gameRef.player)
            {
                player = gameRef.player;
            }

            if (player.warnTrigger)
            {
                warningImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
            else
            {
                warningImage.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            }

            transform.position = new Vector3(
                startPosition.x + Mathf.Sin(Time.time * 100.0f) * 20.0f,
                startPosition.y + Mathf.Sin(Time.time * 80.0f) * 10.0f,
                0.0f
                );
        }
    }
}
