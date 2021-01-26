using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftBoundaries : Boundaries
{
    [SerializeField] [Range(0, 1f)] float StoppingPower;

    protected override void TriggerEffect(Collider2D collision)
    {
        collision.GetComponent<ElementBehaviour>().Rb.velocity *= -StoppingPower;
    }
}
