using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase contiene distintos tipos de efectos visuales "Fade-like"
/// </summary>
public class Faders : MonoBehaviour
{
    [SerializeField] [Range(0, 3)] float timeToFade = 1;

    [SerializeField] bool UseRenderer = false;
    [Space]
    [SerializeField] bool FadeOutOnStart = false;
    [SerializeField] bool FadeInOnStart = false;

    private void Start()
    {
        if (FadeOutOnStart)
        {
            StartCoroutine(FadeOut(timeToFade));
        }

        if (FadeInOnStart)
        {
            StartCoroutine(FadeIn(timeToFade));
        }
    }

    IEnumerator FadeOut(float aTime)
    {
        if (UseRenderer)
        {
            GetComponent<Renderer>().material.color = Color.white;
            float alpha = GetComponent<Renderer>().material.color.a;

            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
            {
                Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, 0, t));
                GetComponent<Renderer>().material.color = newColor;
                yield return null;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            float alpha = GetComponent<SpriteRenderer>().color.a;

            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
            {
                Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, 1, t));
                GetComponent<SpriteRenderer>().color = newColor;
                yield return null;

            }
        }
    }

    IEnumerator FadeIn(float aTime)
    {
        if (UseRenderer)
        {
            GetComponent<Renderer>().material.color = Color.clear;
            float alpha = GetComponent<Renderer>().material.color.a;

            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
            {
                Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, 1, t));
                GetComponent<Renderer>().material.color = newColor;
                yield return null;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.clear;
            float alpha = GetComponent<SpriteRenderer>().color.a;

            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
            {
                Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, 1, t));
                GetComponent<SpriteRenderer>().color = newColor;
                yield return null;
            }
        }
    }
}
