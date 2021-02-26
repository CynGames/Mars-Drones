using System;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Serialization;

public class Objective : MonoBehaviour
{
    [TextArea] public string CurrentObjective_ES; 
    [TextArea] public string CurrentObjective_EN; 
    [TextArea] public string CurrentObjective_PT;

    private void Start()
    {
        UpdateObjective();
    }

    public void UpdateObjective()
    {
        // En teoria esto funca.
        string currentLang = Localization.Language;
        
        switch (currentLang)
        {
            case "es":
                ObjectiveManager.Instance.SetCurrentObjective(CurrentObjective_ES);
                break;
            case "en":
                ObjectiveManager.Instance.SetCurrentObjective(CurrentObjective_EN);
                break;
            case "pt":
                ObjectiveManager.Instance.SetCurrentObjective(CurrentObjective_PT);
                break;
        }
    }
}
