using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace com.novega.ludumdare48
{
    public class PlayFootstep : MonoBehaviour
    {
        public enum GroundType
        {
            Grass, Dirt, Concrete, Wood
        };
        public GroundType groundType = GroundType.Concrete;

        [SerializeField] PlayRandomSound grassSounds;
        [SerializeField] PlayRandomSound dirtSounds;
        [SerializeField] PlayRandomSound concreteSounds;
        [SerializeField] PlayRandomSound woodSounds;

        public void PlayCurrentSound()
        {
            switch (groundType)
            {
                case GroundType.Grass:
                    grassSounds.PickSound(true, .2f);
                    break;
                case GroundType.Dirt:
                    dirtSounds.PickSound(true, .2f);
                    break;
                case GroundType.Concrete:
                    concreteSounds.PickSound(true, .25f);
                    break;
                case GroundType.Wood:
                    woodSounds.PickSound(true, .7f);
                    break;
            }
        }
    }
}