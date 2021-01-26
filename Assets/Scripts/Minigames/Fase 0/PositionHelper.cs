using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PositionHelper : MonoBehaviour
{
    [SerializeField] protected List<Transform> exitPoints = new List<Transform>();
    protected int currentExitPointTurn = 0;

    protected void TeleportElemenToPosition(Collider2D collision)
    {
        collision.attachedRigidbody.velocity *= -1;
        collision.attachedRigidbody.MovePosition(exitPoints[currentExitPointTurn].transform.position);

        ReadyNextExitPoint(ref currentExitPointTurn, exitPoints.Count);
    }

    protected void ReadyNextExitPoint(ref int currentExitPointTurn, int amountOfExitPoints)
    {
        if (currentExitPointTurn + 1 == amountOfExitPoints)
            currentExitPointTurn = 0;
        else
            currentExitPointTurn++;
    }
}