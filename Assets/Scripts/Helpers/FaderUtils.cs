using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FaderUtils
{
    public static IEnumerator SrenFadeIn(SpriteRenderer targetSren, float duration, bool keepCurrentValue, float to = 1)
    {
        if (keepCurrentValue == false)
        {
            targetSren.color = Color.clear;
        }

        float alpha = targetSren.color.a;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / duration)
        {
            Color newColor = new Color(to, to, to, Mathf.Lerp(alpha, to, t));
            targetSren.color = newColor;
            yield return null;
        }
    }

    public static IEnumerator SrenFadeOut(SpriteRenderer targetSren, float duration, bool keepCurrentValue, Color color, float to = 0)
    {
        if (keepCurrentValue == false)
        {
            targetSren.color = Color.white;
        }
        float alpha = targetSren.color.a;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / duration)
        {
            Color newColor = new Color(color.r, color.b, color.g, Mathf.Lerp(alpha, to, t));
            targetSren.color = newColor;
            yield return null;
        }
    }

    public static IEnumerator SrenBlendToColor(SpriteRenderer targetSren, float duration, Color from, Color to)
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / duration)
        {
            Color newColor = Color.Lerp(from, to, t);
            targetSren.color = newColor;
            yield return null;
        }
    }
}
