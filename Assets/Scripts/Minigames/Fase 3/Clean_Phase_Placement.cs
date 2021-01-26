using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clean_Phase_Placement : MonoBehaviour
{
    public GameObject CleaningToolInstance;

    [SerializeField] SpriteRenderer parentSren;
    bool isAccountedFor;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isAccountedFor == false)
        {
            if (collision.gameObject == CleaningToolInstance)
            {
                parentSren.DOBlendableColor(Color.white, 1);
                isAccountedFor = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == CleaningToolInstance)
        {
            parentSren.DOBlendableColor(Color.gray, 1);
            isAccountedFor = false;
        }
    }


}