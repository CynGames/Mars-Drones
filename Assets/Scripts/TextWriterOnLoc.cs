using System;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using TMPro;
using UnityEngine;

public class TextWriterOnLoc : MonoBehaviour
{
    public TMP_Text textField;
    [Space]
    [TextArea(3,10)] public string textES;
    [TextArea(3,10)] public string textEN;
    [TextArea(3,10)] public string textPT;

    private void Start()
    {
        LocButtons.LangUpdateHandler += OnLangUpdate;
    }

    private void OnLangUpdate()
    {
        switch (Localization.Language)
        {
            case "es":
                textField.text = textES;
                break;
            case "en":
                textField.text = textEN;
                break;
            case "pt":
                textField.text = textPT;
                break;
        }
    }

    private void OnDisable()
    {
        LocButtons.LangUpdateHandler -= OnLangUpdate;
    }
}