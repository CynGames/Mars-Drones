using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardBoundaries : Boundaries
{
    public bool playAnimation = true;

    protected override void TriggerEffect(Collider2D collision)
    {
        if (collision.GetComponent<ElementBehaviour>())
        {
            if (playAnimation)
            {
                collision.GetComponent<ElementBehaviour>().DespawnAndRecall(collision.transform.position, RecallManager.Instance.GetMainDestination(), true);
            }
            else
            {
                collision.gameObject.SetActive(false);
            }
        }
    }
}
