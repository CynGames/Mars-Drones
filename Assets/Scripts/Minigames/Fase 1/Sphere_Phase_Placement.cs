using CrunchTools.AudioSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AdditionalData))]
public class Sphere_Phase_Placement : Placement
{
    public Transform RestSpot;

    AdditionalData.Type type;

    private void Start()
    {
        type = GetComponent<AdditionalData>().type;
    }

    public override bool ReturnPlacementValidation(ElementBehaviour elementBehaviour)
    {
        if (elementBehaviour.data.type.ToString() == type.ToString())
        {
            Debug.Log("true");

            AudioManager.Instance.PlaySound2D("Exito");

            Sphere_Phase_Manager.PlacedElements++;

            return true;
        }
        else
        {
            Debug.Log("false");

            return false;
        }
    }
}
