using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.ludumdare48
{
    public class LightReact : MonoBehaviour
    {
        [SerializeField]
        MeshRenderer mesh;
        [SerializeField]
        GameObject lightObject;
        [SerializeField]
        Material litMaterial;
        [SerializeField]
        Material unlitMaterial;

        public bool lit;

        public void React()
        {
            if (!lit)
            {
                lit = true;
                lightObject.SetActive(true);
                mesh.material = litMaterial;
            }
            else
            {
                lit = false;
                lightObject.SetActive(false);
                mesh.material = unlitMaterial;
            }
        }
    }
}
