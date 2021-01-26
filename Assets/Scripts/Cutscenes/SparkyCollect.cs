using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkyCollect : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Matching_Phase_Placement>() != null)
        {
            Matching_Phase_Placement slot = collision.GetComponent<Matching_Phase_Placement>();

            if (slot.GetLockedStatus() == true)
            {
                slot.UpdateSprite();

                Matching_Phase_Manager.Instance.SlotsCompleted--;
            }
        }
    }

    public void ReadyNextDrone()
    {
        if (Matching_Phase_Manager.Instance.DroneNumber == 3)
        {
            Matching_Phase_Manager.Instance.MinigameOver();

            return;
        }

        Matching_Phase_Manager.Instance.spawnAvailable = true;

        Destroy(gameObject);
    }
}
