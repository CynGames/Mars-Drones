using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using CrunchTools.AudioSystem;
using PixelCrushers.DialogueSystem;
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

        textClock.text = minutes + " : " + seconds + " ";
    }

    void GetPerformancePercentile()
    {
        string outcome;
        var percent = ((GameManager.Phase4Time / GameManager.Phase0Time) * 100f - 100) * -1f;
        Percent.text = $"{percent:F2} %";
        
        if (percent <= 0)
        {
            outcome = 
                (Localization.Language == "es") ? "...¡¿hubo mejor rendimiento SIN las 5S..?!" : 
                (Localization.Language == "en") ? "... there was better performance WITHOUT 5S ..?!" :
                "... teve melhor desempenho SEM 5S ..?!";
            
            
        }
        else if (percent > 0 && percent <= 20)
        {
            outcome = 
                (Localization.Language == "es") ? "¡Tuviste una ligera mejoría en tu eficiencia!" : 
                (Localization.Language == "en") ? "You had a slight improvement in your efficiency!" :
                "Você teve uma ligeira melhora em sua eficiência!";
        }
        else if (percent > 20 && percent <= 50)
        {
            outcome = 
                (Localization.Language == "es") ? "¡Felicidades! ¡Tuviste una muy buena mejora en tiempo!" : 
                (Localization.Language == "en") ? "Congratulations! You had a very good improvement in time!" :
                "Parabéns! Você teve uma melhora muito boa no tempo!";
        }
        else
        {
            outcome = 
                (Localization.Language == "es") ? "¡Excelente rendimiento! ¡Tu mejora de tiempo fue enorme!" : 
                (Localization.Language == "en") ? "Excellent performance! Your time improvement was huge!" :
                "Excelente desempenho! A sua melhoria de tempo foi enorme!";
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