using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloatTween : MonoBehaviour
{
    [SerializeField] float multiplier = 1f;
    [SerializeField] float seconds = 1f;

    // This script uses DOTween to make an object smoothly float up and down.
    void Start()
    {
        transform.DOMove(transform.position + (Vector3.up * multiplier), seconds)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutQuad);
    }
}
