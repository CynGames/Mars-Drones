using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FadeBlink : MonoBehaviour
{
    [Range(0.1f, 1)] public float blinkDuration;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        StartCoroutine(BlinkRoutine());
    }

    private IEnumerator BlinkRoutine()
    {
        while (true)
        {
            _renderer.DOFade(1, blinkDuration);
            yield return new WaitForSeconds(blinkDuration);

            _renderer.DOFade(0, blinkDuration);
            yield return new WaitForSeconds(blinkDuration);
        }
    }
    
    
}