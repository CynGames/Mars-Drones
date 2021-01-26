using PixelCrushers.DialogueSystem;
using PixelCrushers.DialogueSystem.SequencerCommands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencerCommandTargetedFade : SequencerCommand
{
    string targetName;
    float fadeDuration;

    private void Awake()
    {
        targetName = GetParameter(0);
        fadeDuration = GetParameterAsFloat(1);
    }

    void Start()
    {
        StartCoroutine(FadeIn(targetName, fadeDuration));
    }

    IEnumerator FadeIn(string targetName, float aTime)
    {
        GameObject go = GameObject.Find(targetName).gameObject;
        go.GetComponent<SpriteRenderer>().color = Color.clear;

        float alpha = go.GetComponent<SpriteRenderer>().color.a;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, 1, t));
            go.GetComponent<SpriteRenderer>().color = newColor;
            yield return null;
        }

        Stop();
    }
}
