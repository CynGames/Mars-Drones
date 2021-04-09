using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class ConversationValidator : MonoBehaviour
{
    public static bool hasStartedGame;

    void Start()
    {
        if(!hasStartedGame) GetComponent<DialogueSystemTrigger>().OnUse();
    }
}
