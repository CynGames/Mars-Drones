using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningBoundaries : MonoBehaviour
{
    [SerializeField] bool isCleanZone;
    [SerializeField] Transform targetSpot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Clean_Phase_Papel>())
        {
            if (isCleanZone == false)
            {
                collision.GetComponent<Clean_Phase_Papel>().InstanciateRecallLight();
            }
            else
            {
                collision.GetComponent<Clean_Phase_Papel>().CleanUp(targetSpot.position);
            }
        }
    }
}
