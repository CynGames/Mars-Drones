using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matching_Phase_Element_Behaviour : ElementBehaviour
{
    protected override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);

        if (isBeingDragged == false && placed == false)
        {
            if (collision.GetComponent<Placement>())
            {
                if (TryPlacementValidity(collision.GetComponent<Placement>()))
                {
                    SmoothPlacement(collision.transform.position);

                    placed = true;
                }
                else
                {
                    Instantiate(RecallLight, transform.position, Quaternion.identity);

                    gameObject.SetActive(false);
                }

                return;
            }

            if (collision.GetComponent<Boundaries>() != null)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
