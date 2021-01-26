using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocation : PositionHelper
{
    protected Spawner spawner;

    protected void OnValidate()
    {
        spawner = spawner ?? FindObjectOfType<Spawner>();

        if (!spawner)
        {
            Debug.LogWarning("No se encontró un [Spawner] en la escena!");
        }
    }

    public void PositionElement(GameObject inactiveElement)
    {
        inactiveElement.transform.position = exitPoints[currentExitPointTurn].transform.position;
        inactiveElement.SetActive(true);

        ReadyNextExitPoint(ref currentExitPointTurn, exitPoints.Count);
    }
}