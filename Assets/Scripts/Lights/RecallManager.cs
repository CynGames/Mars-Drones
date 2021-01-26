using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class RecallManager : MonoBehaviour
{
    public static RecallManager Instance;

    [SerializeField] Transform MainDestination;
    [SerializeField] Transform AlternativeDestination;

    private void Awake()
    {
        AnalyticsEvent.LevelStart("ThirdLevel");
        
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public Transform GetMainDestination()
    {
        if (MainDestination)
            return MainDestination;
        else
            return null;
    }

    public Transform GetAlternativeDestination()
    {
        if (AlternativeDestination)
            return AlternativeDestination;
        else
            return null;
    }
}
