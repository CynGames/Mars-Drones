using CrunchTools.AudioSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Matching_Phase_Manager : Manager
{
    public static Matching_Phase_Manager Instance;

    [Space]
    public bool isThisPhase4;
    public GameObject SparkyEND;
    [Space]

    public GameObject SparkyCollector;

    public int DroneNumber;
    public int SlotsCompleted;

    public bool spawnAvailable = true;

    private void Awake()
    {
        AnalyticsEvent.LevelStart("FourthLevel");
        
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    private void Update()
    {
        if (SlotsCompleted == 6 && spawnAvailable == true)
        {
            spawnAvailable = false;
            DroneNumber++;

            //animacion
            Instantiate(SparkyCollector);
        }

        if (PixelCrushers.DialogueSystem.DialogueManager.IsConversationActive == false)
        {
            isTimeAdvancing = true;
        }
        else
        {
            isTimeAdvancing = false;
        }

        PhaseTimer();
    }

    private void PhaseTimer()
    {
        if (isTimeAdvancing)
            MinigameTime += Time.deltaTime;
    }

    public override void MinigameOver()
    {
        isTimeAdvancing = false;

        if (isThisPhase4 == false)
        {
            GameManager.Phase0Time = Mathf.RoundToInt(MinigameTime);

            Analytics.CustomEvent("Phase0Time", new Dictionary<string, object>()
            {
                { "Time" , GameManager.Phase0Time}
            });
        }
        else
        {
            GameManager.Phase4Time = Mathf.RoundToInt(MinigameTime);
            
            Analytics.CustomEvent("Phase4Time", new Dictionary<string, object>()
            {
                { "Time" , GameManager.Phase4Time}
            });
        }

        SparkyEND.SetActive(true);
    }
}