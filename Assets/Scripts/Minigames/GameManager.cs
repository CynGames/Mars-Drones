using CrunchTools.AudioSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool isPaused = false;

    public static float Phase0Time = 0;
    public static float Phase1Time = 0;
    public static float Phase2Time = 0;
    public static float Phase3Time = 0;
    public static float Phase4Time = 0;

    public bool reset;

    private void Awake()
    {
        PlayerPrefs.SetFloat("sfx vol", .15f);
    }

    private void Start()
    {
        isPaused = false;
    }

    private void Update()
    {
        PlayerPrefs.SetFloat("sfx vol", .15f);
    }

    public static void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;

        Debug.Log("Paused");
    }

    public static void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;

        Debug.Log("Resumed");
    }
}