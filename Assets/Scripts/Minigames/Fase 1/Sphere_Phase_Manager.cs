using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Sphere_Phase_Manager : Manager
{
    public static Sphere_Phase_Manager Instance;

    public static int PlacedElements;
    public int TotalElements;
    [Space]
    public bool isThisPhase2;
    public GameObject SparkyEND;
    [Space]
    QueueAssembler QueueAssembler;
    bool countReady;


    private void Awake()
    {
        PlacedElements = 0;
        AnalyticsEvent.LevelStart("SecondLevel");

        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        QueueAssembler = QueueAssembler ? QueueAssembler : GetComponent<QueueAssembler>();
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

        SetTotalCount();

        CheckForVictoryCondition();

        PhaseTimer();
    }

    private void SetTotalCount()
    {
        if (countReady == false)
        {
            TotalElements = QueueAssembler.QueuedElements.Count;
            countReady = true;
        }
    }

    private void CheckForVictoryCondition()
    {
        if (PlacedElements == TotalElements)
        {
            MinigameOver();
        }
    }

    private void PhaseTimer()
    {
        if (isTimeAdvancing)
            MinigameTime += Time.deltaTime;
    }

    public override void MinigameOver()
    {
        isTimeAdvancing = false;

        if (isThisPhase2)
        {
            GameManager.Phase2Time = Mathf.RoundToInt(MinigameTime);
            
            Analytics.CustomEvent("Phase2Time", new Dictionary<string, object>()
            {
                { "Time" , GameManager.Phase2Time}
            });
        }
        else
        {
            GameManager.Phase1Time = Mathf.RoundToInt(MinigameTime);
            
            Analytics.CustomEvent("Phase3Time", new Dictionary<string, object>()
            {
                { "Time" , GameManager.Phase3Time}
            });
        }

        SparkyEND.SetActive(true);
    }
}
