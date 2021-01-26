using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecallLight : MonoBehaviour
{
    public Transform RecallDestination;
    public Vector2 RecallPosition;

    protected virtual void Start()
    {
        if (RecallDestination)
        {
            MoveToSpawn();
        }
        else if (RecallPosition != Vector2.zero)
        {
            MoveToPosition();
        }
        else
        {
            DeactivateCallback();
        }
    }

    protected virtual void MoveToSpawn()
    {
        if (RecallDestination == null)
        {
            DeactivateCallback();
            return;
        }

        transform.DOMove(RecallDestination.position, 1).SetEase(Ease.OutCubic).OnComplete(ScaleDownCallback);
    }

    protected virtual void MoveToPosition()
    {
        transform.DOMove(RecallPosition, 1).SetEase(Ease.OutCubic).OnComplete(ScaleDownCallback);
    }

    protected virtual void ScaleDownCallback()
    {
        transform.DOScale(0, 1).OnComplete(DeactivateCallback);
    }

    protected virtual void DeactivateCallback()
    {
        gameObject.SetActive(false);
    }

    public void ChangeColor(Color color)
    {
        transform.GetChild(0).GetComponent<TrailRenderer>().startColor = color;
    }
}