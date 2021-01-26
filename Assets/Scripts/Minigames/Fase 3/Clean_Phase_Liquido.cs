using CrunchTools.AudioSystem;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Clean_Phase_Liquido : Clean_Phase_Dirt_Element
{
    [SerializeField] float startingPoints;
    [SerializeField] float dirtyPoints;

    [SerializeField] [Range(0, 1)] float minSize;

    private void Start()
    {
        dirtyPoints = startingPoints;
    }

    protected override void CorrectToolInStay()
    {
        dirtyPoints--;

        SetSize();
    }

    private void SetSize()
    {
        if (transform.localScale.magnitude >= (Vector2.one * minSize).magnitude)
        {
            transform.localScale = Vector2.one * (dirtyPoints / startingPoints);
        }

        if (dirtyPoints <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        //algun puntaje o tracking
        AudioManager.Instance.PlaySound2D("Exito");

        Clean_Phase_Manager.Instance.ElementsCleaned++;
    }

    protected override void CorrectToolInRange()
    {
        if (cleaningTool.GetComponent<Clean_Phase_Cleaning_Element>().isBeingDragged == true)
        {
            dirtyPoints -= 25;

            SetSize();
        }


        return;
    }

    protected override void IncorrectToolInRange()
    {
        if (cleaningTool.GetComponent<Clean_Phase_Cleaning_Element>().isBeingDragged == true)
        {
            dirtyPoints -= 25;

            SetSize();
        }

        return;
    }
}
