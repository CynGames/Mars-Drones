using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroEffects : MonoBehaviour
{
    [SerializeField] protected GameObject FirstSlide;
    [SerializeField] public GameObject SecondSlide;

    protected void Start()    
    {
        gameObject.GetComponent<Image>().material.DOFade(1, 0);

        LogoRevealSequence();
    }

    private void LogoRevealSequence()
    {
        gameObject.GetComponent<Image>().DOFade(0, 3).OnComplete(FadeIn);
    }

    private void FadeIn()
    {
        gameObject.GetComponent<Image>().DOFade(1, 3).OnComplete(RevealSecondSlide);
    }

    private void RevealSecondSlide()
    {
        FirstSlide.SetActive(false);
        SecondSlide.SetActive(true);

        gameObject.GetComponent<Image>().DOFade(0, 3).OnComplete(SecondFadeIn);
    }

    protected virtual void SecondFadeIn()
    {
        gameObject.GetComponent<Image>().DOFade(1, 3).OnComplete(EndCutscene);
    }

    protected virtual void EndCutscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
