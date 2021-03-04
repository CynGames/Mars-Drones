using System;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class LocButtons : MonoBehaviour
{
    public string langCode;
    public Animator animator;
    
    public static event Action LangUpdateHandler;

    public void SetLanguage()
    {
        GameManager.LocSetting = langCode;
        
        LangUpdateHandler?.Invoke();
    }

    public void TriggerOutroAnimation()
    {
        animator.SetTrigger("Trigger_Outro");
    }
}
