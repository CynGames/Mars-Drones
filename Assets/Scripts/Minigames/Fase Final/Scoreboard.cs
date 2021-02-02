using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using CrunchTools.AudioSystem;
using UnityEngine.Analytics;

public class Scoreboard : MonoBehaviour
{
    [Header("Normal Scoreboard")]
    public TMP_Text Phase0;
    public TMP_Text Phase1;
    public TMP_Text Phase2;
    public TMP_Text Phase3;
    public TMP_Text Phase4;
    
    [Header("Percent Scoreboard")]
    public TMP_Text Percent;
    public TMP_Text Outcome;

    [Space]
    public AudioClip bgm;

    private void Awake()
    {
        //AudioManager.Instance.PlayMusic(MusicLibrary.reversedMusicDict[bgm]);
    }

    private void Start()
    {
        if (GameManager.Phase0Time > 0)
            SetTimeResults(ref Phase0, GameManager.Phase0Time);
        else
            return;

        if (GameManager.Phase1Time > 0)
            SetTimeResults(ref Phase1, GameManager.Phase1Time);
        else
            return;
        
        if (GameManager.Phase2Time > 0)
            SetTimeResults(ref Phase2, GameManager.Phase2Time);
        else
            return;
        
        if (GameManager.Phase3Time > 0)
            SetTimeResults(ref Phase3, GameManager.Phase3Time);
        else
            return;
        
        if (GameManager.Phase4Time > 0)
            SetTimeResults(ref Phase4, GameManager.Phase4Time);
        else
            return;

        GetPerformancePercentile();
        
        ClearScores();
    }

    void SetTimeResults(ref TMP_Text textClock, float phaseTime)
    {
        float t = Mathf.RoundToInt(phaseTime);
        string minutes = ((int)t / 60).ToString("0#");
        string seconds = (t % 60).ToString("#");

        textClock.text = minutes + "mins " + seconds + "segs";
    }

    void GetPerformancePercentile()
    {
        string outcome;
        var percent = ((GameManager.Phase4Time / GameManager.Phase0Time) * 100f - 100) * -1f;
        Percent.text = $"{percent:F2} %";
        
        if (percent <= 0)
        {
            outcome = "...hubo mejor rendimiento SIN las 5S..?!";
        }
        else if (percent > 0 && percent <= 20)
        {
            outcome = "Tuviste una ligera mejora en tu eficiencia!";
        }
        else if (percent > 20 && percent <= 50)
        {
            outcome = "Felicidades! Tuviste una muy buena mejora en tiempo!";
        }
        else
        {
            outcome = "Excelente rendimiento! Tu mejora de tiempo fue enorme!";
        }

        Outcome.text = outcome;

        Analytics.CustomEvent("EndingResults", new Dictionary<string, object>
        {
            { "Phase 0", Phase0.text },
            { "Phase 1", Phase1.text },
            { "Phase 2", Phase2.text },
            { "Phase 3", Phase3.text },
            { "Phase 4", Phase4.text },
            { "PerformancePercentile", percent }
        });
    }

    public void GoToMenu()
    {
        AnalyticsEvent.LevelComplete("FinalScoreboard");
        
        FindObjectOfType<ButtonsFunctions>().ChangeScene("MainMenu");
    }

    private static void ClearScores()
    {
        GameManager.Phase0Time = 0;
        GameManager.Phase1Time = 0;
        GameManager.Phase2Time = 0;
        GameManager.Phase3Time = 0;
        GameManager.Phase4Time = 0;
    }

    public void GoToNextScene()
    {
        ButtonsFunctions.Instance.ChangeScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}