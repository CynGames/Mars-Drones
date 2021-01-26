using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clean_Phase_Manager : Manager
{
    public static Clean_Phase_Manager Instance;

    public int ElementsCleaned;
    [Space]
    [SerializeField] GameObject SparkyEND;
    [SerializeField] Transform elementsParent;

    int TotalElements;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        TotalElements = elementsParent.childCount;
    }

    private void Update()
    {
        if (PixelCrushers.DialogueSystem.DialogueManager.IsConversationActive == false)
        {
            isTimeAdvancing = true;
        }
        else
        {
            isTimeAdvancing = false;
        }

        if (isTimeAdvancing)
            MinigameTime += Time.deltaTime;

        if (ElementsCleaned == TotalElements)
        {
            MinigameOver();
        }
    }

    public override void MinigameOver()
    {
        isTimeAdvancing = false;
        GameManager.Phase3Time = Mathf.RoundToInt(MinigameTime);

        SparkyEND.SetActive(true);
    }
}
