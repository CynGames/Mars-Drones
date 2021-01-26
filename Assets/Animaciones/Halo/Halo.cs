using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halo : MonoBehaviour
{
    [SerializeField] Transform targetSpot;
    [SerializeField] float durationTime;

    // Start is called before the first frame update
    void Start()
    {
        StartTween();
    }

    private void StartTween()
    {
        transform.DOMove(targetSpot.position, durationTime).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }
}
