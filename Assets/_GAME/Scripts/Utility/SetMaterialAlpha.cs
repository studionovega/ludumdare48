using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaterialAlpha : MonoBehaviour
{
    [SerializeField] Material material;
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
            SetAlpha(d);
        } else
        {
            SetAlpha(255);
        }
        if (d > maxDistance)
        {
            SetAlpha(0);
        }
    }

    public void SetAlpha(float alpha)
    {
        Color color = material.color;
        color.a = alpha;
        material.color = color;
    }
}
