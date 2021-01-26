using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boundaries : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ElementBehaviour>())
            if (collision.GetComponent<ElementBehaviour>().isBeingDragged == false)
                TriggerEffect(collision);
    }

    protected abstract void TriggerEffect(Collider2D collision);
}
