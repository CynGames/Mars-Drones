using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeScreen : MonoBehaviour
{
    SpriteRenderer Sren;

    void Start()
    {
        Sren = Sren ?? GetComponent<SpriteRenderer>();

        Sren.DOFade(.5f, 2);
    }
}
