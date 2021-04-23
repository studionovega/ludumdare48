using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.novega.ludumdare48
{
    public class BS_OpenSite : MonoBehaviour
    {
        [SerializeField] string url;

        public void OpenSite()
        {
            Application.OpenURL(url);
        }
    }
}
