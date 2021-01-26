using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clean_Phase_Cleaning_Element : MonoBehaviour
{
    public bool isBeingDragged;

    public enum ToolType
    {
        Escoba,
        Esponja
    }
    public ToolType type;

    [SerializeField] Transform ResetingSpot;
    [SerializeField] RecallLight RecallLight;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer Sren;
    [SerializeField] CircleCollider2D CircleCollider;
    [SerializeField] Rigidbody2D Rb;

    protected virtual void OnStartDrag()
    {
        isBeingDragged = true;

        animator.SetBool("IsBeingDragged", isBeingDragged);
        CircleCollider.enabled = false;

        transform.DOScale(.75f, .15f);
    }

    protected virtual void OnStopDrag()
    {
        isBeingDragged = false;

        animator.SetBool("IsBeingDragged", isBeingDragged);
        CircleCollider.enabled = true;

        RecallElement();
    }

    private void RecallElement()
    {
        InstanciateRecallLight();
    }

    void InstanciateRecallLight()
    {
        RecallLight recallLight = Instantiate(RecallLight, transform.position, Quaternion.identity).GetComponent<RecallLight>();
        recallLight.RecallDestination = ResetingSpot;
        RecallLight.ChangeColor(Color.red);

        Sren.DOFade(0, .15f).OnComplete(ResetState);
    }

    void ResetState()
    {
        transform.position = ResetingSpot.position;
        transform.localScale = Vector2.one * .25f;
        Rb.velocity = Vector2.zero;

        Sren.DOFade(1, .15f).SetDelay(1);
    }
}
