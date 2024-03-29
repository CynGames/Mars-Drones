﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Sphere_Phase_Element_Behaviour : ElementBehaviour
{
    protected override void OnTriggerStay2D(Collider2D collision)
    {
        //si deactivate stay esta off...
        base.OnTriggerStay2D(collision);

        if (isBeingDragged == false && placed == false)
        {
            if (collision.GetComponent<Sphere_Phase_Placement>())
            {
                if (TryPlacementValidity(collision.GetComponent<Sphere_Phase_Placement>()))
                {
                    SmoothPlacement(collision.GetComponent<Sphere_Phase_Placement>().RestSpot.position);

                    Destroy(GetComponent<CircleCollider2D>());
                    Rb.gravityScale = 0;

                    placed = true;
                }

                return;
            }
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        Rb.gravityScale = 0;
        Destroy(GetComponent<CircleCollider2D>());
    }
}