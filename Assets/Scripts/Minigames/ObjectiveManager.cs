using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager Instance;
    
    public TMP_Text ObjBody;
    
    [TextArea] public string NoObjective;
    [TextArea] public string MainMenu;
    [TextArea] public string PhaseZero;
    [TextArea] public string PhaseOne;
    [TextArea] public string PhaseTwo;
    [TextArea] public string PhaseThree;
    [TextArea] public string PhaseFour;

    private void Awake()
    {
        Instance = this;
    }



    public void SetCurrentObjective(string obj)
    {
        ObjBody.text = obj;
    }
}
