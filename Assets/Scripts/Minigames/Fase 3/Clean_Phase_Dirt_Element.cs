using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Clean_Phase_Dirt_Element: MonoBehaviour
{
    [SerializeField] protected GameObject cleaningTool;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == cleaningTool)
        {
            CorrectToolInRange();
        }
        else
        {
            IncorrectToolInRange();
        }
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == cleaningTool)
        {
            CorrectToolInStay();
        }
    }

    protected abstract void CorrectToolInRange();

    protected abstract void CorrectToolInStay();

    protected abstract void IncorrectToolInRange();
}