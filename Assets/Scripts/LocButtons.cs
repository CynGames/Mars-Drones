using System;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class LocButtons : MonoBehaviour
{
    public string langCode;

    public static event Action LangUpdateHandler;

    public void SetLanguage()
    {
        Localization.Language = langCode;
        
        LangUpdateHandler?.Invoke();
    }
}
