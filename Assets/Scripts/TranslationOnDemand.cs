using System;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class TranslationOnDemand : MonoBehaviour
{
    public TMP_Text textField;
    
    private void Start()
    {
        textField = textField ?? GetComponent<TMP_Text>();
    }

    public void RealTimeTranslator(string text)
    {
        switch (GameManager.LocSetting)
        {
            case "es":
                textField.text = TranslateToES(text);
                break;
            case "en":
                textField.text = TranslateToEN(text);
                break;
            case "pt":
                textField.text = TranslateToPT(text);
                break;
        }
    }
    
    private string TranslateToES(string currentTextDisplayed)
    {
        if (currentTextDisplayed.Equals("FABRICAÇÃO") || currentTextDisplayed.Equals("MANUFACTURING"))
        {
            return "FABRICACION";
        }
        
        if (currentTextDisplayed.Equals("FERRAMENTA") || currentTextDisplayed.Equals("TOOL"))
        {
            return "HERRAMIENTA";
        }
        
        return "BASURA";
    }
    
    private string TranslateToEN(string currentTextDisplayed)
    {
        if (currentTextDisplayed.Equals("FABRICAÇÃO") || currentTextDisplayed.Equals("FABRICACION"))
        {
            return "MANUFACTURING";
        }
        
        if (currentTextDisplayed.Equals("FERRAMENTA") || currentTextDisplayed.Equals("HERRAMIENTA"))
        {
            return "TOOL";
        }
        
        return "TRASH";
    }

    private string TranslateToPT(string currentTextDisplayed)
    {
        if (currentTextDisplayed.Equals("FABRICACION") || currentTextDisplayed.Equals("MANUFACTURING"))
        {
            return "FABRICAÇÃO";
        }
        
        if (currentTextDisplayed.Equals("HERRAMIENTA") || currentTextDisplayed.Equals("MANUFACTURING"))
        {
            return "FERRAMENTA";
        }
        
        return "LIXO";
    }
}