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
        if (currentTextDisplayed.Equals("FABRICACION"))
        {
            return "FABRICACION";
        }
        
        if (currentTextDisplayed.Equals("HERRAMIENTA"))
        {
            return "HERRAMIENTA";
        }

        if (currentTextDisplayed.Equals("ELECTRICO")) 
        {
            return "ELECTRICO";
        }
        
        if (currentTextDisplayed.Equals("MECANICO"))
        {
            return "MECANICO";
        }
        
        return "BASURA";
    }
    
    private string TranslateToEN(string currentTextDisplayed)
    {
        if (currentTextDisplayed.Equals("FABRICACION"))
        {
            return "MANUFACTURING";
        }
        
        if (currentTextDisplayed.Equals("HERRAMIENTA"))
        {
            return "TOOL";
        }
        
        if (currentTextDisplayed.Equals("ELECTRICO")) 
        {
            return "ELECTRIC";
        }
        
        if (currentTextDisplayed.Equals("MECANICO"))
        {
            return "MECHANICAL";
        }
        
        return "TRASH";
    }

    private string TranslateToPT(string currentTextDisplayed)
    {
        if (currentTextDisplayed.Equals("FABRICACION"))
        {
            return "FABRICAÇÃO";
        }
        
        if (currentTextDisplayed.Equals("HERRAMIENTA"))
        {
            return "FERRAMENTA";
        }
        
        if (currentTextDisplayed.Equals("ELECTRICO")) 
        {
            return "ELÉTRICO";
        }
        
        if (currentTextDisplayed.Equals("MECANICO"))
        {
            return "MECÂNICO";
        }
        
        return "LIXO";
    }
}