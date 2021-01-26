using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransponderLight : RecallLight
{
    [SerializeField] [Range(.05f, 1f)] float timeRange = .5f;

    protected override void MoveToSpawn()
    {
        transform.DOMove(RecallDestination.position, timeRange).SetEase(Ease.OutQuart).OnComplete(DeactivateCallback);
    }

    public void SetTarget(Vector2 targetPosition)
    {
        RecallDestination.position = targetPosition;
    }
}