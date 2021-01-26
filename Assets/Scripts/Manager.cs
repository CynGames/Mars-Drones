using CrunchTools.AudioSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Manager : MonoBehaviour
{
    public bool isTimeAdvancing;
    public float MinigameTime;

    public AudioClip bgm;

    private void Start()
    {
        AudioManager.Instance.PlayMusic(MusicLibrary.reversedMusicDict[bgm]);
    }

    public abstract void MinigameOver();
}
