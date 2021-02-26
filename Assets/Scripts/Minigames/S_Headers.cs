using System;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using TMPro;
using UnityEngine;

public class S_Headers : MonoBehaviour
{
    private TMP_Text _headerField;
    
    public string esHeaderContent = "";
    public string enHeaderContent = "";
    public string ptHeaderContent = "";

    private void Start()
    {
        _headerField = GetComponent<TMP_Text>();
        
        // En teoria esto funca.
        string currentLang = Localization.language;

        switch (currentLang)
        {
            case "es":
                _headerField.text = esHeaderContent;
                break;
            case "en":
                _headerField.text = enHeaderContent;
                break;
            case "pt":
                _headerField.text = ptHeaderContent;
                break;
        }
    }
}
