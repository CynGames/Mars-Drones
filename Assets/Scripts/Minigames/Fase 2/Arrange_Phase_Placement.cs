using CrunchTools.AudioSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrange_Phase_Placement : Placement
{
    public Transform RestSpot;

    AdditionalData.SecondaryType SecType;

    private void Start()
    {
        SecType = GetComponent<AdditionalData>().SecType;
    }

    public override bool ReturnPlacementValidation(ElementBehaviour elementBehaviour)
    {
        if (elementBehaviour.data.SecType.ToString() == SecType.ToString())
        {
            Debug.Log("true");

            if(AudioManager.Instance != null) AudioManager.Instance.PlaySound2D("Exito");

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
