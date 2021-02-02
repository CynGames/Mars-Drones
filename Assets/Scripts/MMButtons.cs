using System;
using CrunchTools.AudioSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class MMButtons : MonoBehaviour
{
    ButtonsFunctions ButtonsFunctions;

    public AudioClip bgm;

    private void Awake()
    {
        ButtonsFunctions = ButtonsFunctions ? ButtonsFunctions : FindObjectOfType<ButtonsFunctions>();
    }

    private void Start()
    {
        AudioManager.Instance.PlayMusic(MusicLibrary.reversedMusicDict[bgm]);
    }

    public void StartGame()
    {
        AnalyticsEvent.LevelStart("FirstLevel");
        ButtonsFunctions.Instance.ChangeScene("Fase 0");
    }

    public void QuitGame()
    {
        AnalyticsEvent.GameOver();
        Application.Quit();
    }

    public void Credits()
    {
        AnalyticsEvent.ScreenVisit(ScreenName.Credits);
        ButtonsFunctions.Instance.ChangeScene("Credits");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }
}
