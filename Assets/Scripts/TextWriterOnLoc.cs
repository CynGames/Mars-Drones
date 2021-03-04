using System;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using TMPro;
using UnityEngine;

public class TextWriterOnLoc : MonoBehaviour
{
    public bool checkForLocSettings = true;
    public TMP_Text textField;
    [Space]
    [TextArea(3,10)] public string textES;
    [TextArea(3,10)] public string textEN;
    [TextArea(3,10)] public string textPT;

    private void Start()
    {
        LocButtons.LangUpdateHandler += OnLangUpdate;

        textField = textField ?? GetComponent<TMP_Text>();
        
        if (checkForLocSettings)
        {
            OnLangUpdate();
        }
    }

    private void OnLangUpdate()
    {
        switch (GameManager.LocSetting)
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