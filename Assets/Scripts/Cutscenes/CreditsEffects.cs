using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsEffects : IntroEffects
{
    public GameObject ThirdSlide;
    public GameObject FourthSlide;

    protected override void SecondFadeIn()
    {
        gameObject.GetComponent<Image>().DOFade(1, 3).OnComplete(RevealThirdSlide);
    }

    private void RevealThirdSlide()
    {
        SecondSlide.SetActive(false);
        ThirdSlide.SetActive(true);
        FourthSlide.SetActive(false);

        gameObject.GetComponent<Image>().DOFade(0, 3).OnComplete(ThirdFadeIn);
    }

    private void ThirdFadeIn()
    {
        gameObject.GetComponent<Image>().DOFade(1, 3).OnComplete(RevealFourthSlide);
    }
    
    private void RevealFourthSlide()
    {
        SecondSlide.SetActive(false);
        ThirdSlide.SetActive(false);
        FourthSlide.SetActive(true);

        gameObject.GetComponent<Image>().DOFade(0, 3).OnComplete(FourthFadeIn);
    }

    private void FourthFadeIn()
    {
        gameObject.GetComponent<Image>().DOFade(1, 3).OnComplete(EndCutscene);
    }

    protected override void EndCutscene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
