using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    [TextArea] public string CurrentObjective_ESP; 
    [TextArea] public string CurrentObjective_ENG; 
    [TextArea] public string CurrentObjective_PORT;

    private void Start()
    {
        //if español
        ObjectiveManager.Instance.SetCurrentObjective(CurrentObjective_ESP);
    }
}
