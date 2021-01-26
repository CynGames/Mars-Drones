using CrunchTools.AudioSystem;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matching_Phase_Placement : Placement
{
    [SerializeField] List<GameObject> targetPrefab;

    bool lockedSlot;
    SpriteRenderer sRen;
    SpriteRenderer parentSRen;
    ElementBehaviour placedElement;

    void Awake()
    {
        sRen = sRen ?? GetComponent<SpriteRenderer>();
        parentSRen = parentSRen ?? transform.parent.GetComponent<SpriteRenderer>();
    }

    public override bool ReturnPlacementValidation(ElementBehaviour elementBehaviour)
    {
        if (lockedSlot == true) return false;

        if (elementBehaviour.name.Equals(targetPrefab[Matching_Phase_Manager.Instance.DroneNumber].name))
        {
            Matching_Phase_Manager.Instance.SlotsCompleted++;

            AudioManager.Instance.PlaySound2D("Exito");

            lockedSlot = true;
            parentSRen.DOBlendableColor(Color.white, 1);

            placedElement = elementBehaviour;

            return true;
        }
        else
        {

            return false;
        }
    }

    public bool GetLockedStatus()
    {
        return lockedSlot;
    }

    public void UpdateSprite()
    {
        placedElement.gameObject.SetActive(false);

        lockedSlot = false;

        parentSRen.DOBlendableColor(Color.gray, 1);

        sRen.sprite = targetPrefab[Matching_Phase_Manager.Instance.DroneNumber].GetComponent<SpriteRenderer>().sprite;
    }
}
