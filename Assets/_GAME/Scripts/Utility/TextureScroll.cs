using UnityEngine;
using System.Collections;

namespace com.novega.ludumdare48
{
    public class TextureScroll : MonoBehaviour
    {
        public int materialIndex = 0;
        public Vector2 uvAnimationRate = new Vector2(1.0f, 0.0f);
        public string textureName = "_MainTex";
        Vector2 uvOffset = Vector2.zero;
        Renderer uvRenderer;

        private void Start()
        {
            uvRenderer = GetComponent<Renderer>();
        }

        void LateUpdate()
        {
            uvOffset += (uvAnimationRate * Time.deltaTime);
            if (uvRenderer.enabled)
            {
                uvRenderer.materials[materialIndex].SetTextureOffset(textureName, uvOffset);
            }
        }

    }
}