using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using TMPro;

public class Clock : MonoBehaviour
{
    public TMP_Text textClock;

    Manager manager;

    private void Start()
    {
        manager = manager ?? FindObjectOfType<Manager>();
    }

    void Update()
    {
        if (manager.isTimeAdvancing == true)
        {
            SetClock();
        }
    }

    private void SetClock()
    {
        string minutes = ((int)manager.MinigameTime / 60).ToString("0#");
        string seconds = (manager.MinigameTime % 60).ToString("0#");

        textClock.text = minutes + ":" + seconds;
    }

    //private void CleaningClock()
    //{
    //    string minutes = ((int)Clean_Phase_Manager.Instance.MinigameTime / 60).ToString("0#");
    //    string seconds = (Clean_Phase_Manager.Instance.MinigameTime % 60).ToString("0#");

    //    textClock.text = minutes + ":" + seconds;
    //}
}
