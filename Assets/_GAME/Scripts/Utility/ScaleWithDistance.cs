using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithDistance : MonoBehaviour
{
    [SerializeField] Transform target;//The transform to base alpha on (probably the car's headlights)
    [SerializeField] public float maxDistance = 15f; //how close before we start getting brighter.
    [SerializeField] public float minDistance = 5f; //how close before we stop at max alpha.

    private void Update()
    {
        float d = Vector3.Distance(transform.position, target.position);
        if (d > minDistance)
        {
            d -= minDistance;
            d = d / maxDistance;
            d = 1 - d;
            SetScale(d);
        }
        else
        {
            SetScale(1);
        }
        if (d > maxDistance)
        {
            SetScale(0);
        }
    }

    public void SetScale(float scale)
    {
        transform.localScale = Vector3.one * scale;
    }
}
