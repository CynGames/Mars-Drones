using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation_Raycast_Blocker : MonoBehaviour
{
    public GameObject ConvoBlocker;

    void Update()
    {
        if (DialogueManager.IsConversationActive)
        {
            if (ConvoBlocker.activeSelf == false)
            {
                ConvoBlocker.SetActive(true);
            }
        }
        else
        {
            if (ConvoBlocker.activeSelf == true)
            {
                ConvoBlocker.SetActive(false);
            }
        }
    }
}
