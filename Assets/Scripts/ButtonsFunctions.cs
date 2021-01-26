using PixelCrushers.DialogueSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class ButtonsFunctions : MonoBehaviour
{
    public static ButtonsFunctions Instance;

    public GameObject PauseChild;

    bool isRunning;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && DialogueManager.IsConversationActive == false)
        {
            if (GameManager.isPaused)
            {
                PauseChild.SetActive(false);
                ResumeGame();
            }
            else
            {
                PauseChild.SetActive(true);
                PauseMenu();
            }
        }
    }

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

    public void PauseMenu()
    {
        //Pausar el juego
        GameManager.PauseGame();
    }

    public void ResumeGame()
    {
        //un pausea
        GameManager.ResumeGame();
    }

    public void ChangeScene(string nextScene)
    {
        var sceneName = SceneManager.GetActiveScene().name;
        AnalyticsEvent.LevelQuit($"Quitted at level: {sceneName}");
        
        if (!isRunning)
            StartCoroutine(ChangeSceneRoutine(nextScene));
    }

    public void ChangeScene(int nextSceneID)
    {
        if (!isRunning)
            StartCoroutine(ChangeSceneRoutine(nextSceneID));
    }

    IEnumerator ChangeSceneRoutine(string nextScene)
    {
        //unpausea
        GameManager.ResumeGame();

        isRunning = true;

        //animacion de cerrar las compuertas
        TransitionAnimationHandler.Instance.Closing();

        yield return new WaitForSecondsRealtime(1.5f);

        //cambiar de escene
        SceneManager.LoadScene(nextScene);

        //abrir las puertas
        TransitionAnimationHandler.Instance.Opening();

        isRunning = false;
    }
    
    IEnumerator ChangeSceneRoutine(int nextSceneID)
    {
        //unpausea
        GameManager.ResumeGame();

        isRunning = true;

        //animacion de cerrar las compuertas
        TransitionAnimationHandler.Instance.Closing();

        yield return new WaitForSecondsRealtime(1.5f);

        //cambiar de escene
        SceneManager.LoadScene(nextSceneID);

        //abrir las puertas
        TransitionAnimationHandler.Instance.Opening();

        isRunning = false;
    }
}
