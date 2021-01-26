using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ConveyerTransponder : PositionHelper
{
    [SerializeField] GameObject TransponderLight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ElementBehaviour>().isBeingDragged == false)
        {
            //Saber cual es el punto de spawn inminente
            //TransponderLight.GetComponent<TransponderLight>().SetTarget(exitPoints[currentExitPointTurn].position);

            //Hacer un efecto visual al entrar en contacto con el collider
            //Instantiate(TransponderLight, (Vector2)exitPoints[currentExitPointTurn].position + (Vector2.right * -13), Quaternion.identity);

            Vector2 SpawnPos = (Vector2)exitPoints[currentExitPointTurn].position + (Vector2.right * -13);

            collision.GetComponent<ElementBehaviour>().DespawnAndRecall(SpawnPos, RecallManager.Instance.GetAlternativeDestination(), false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<ElementBehaviour>().isBeingDragged == false)
        {
            //posiciona el elemento
            TeleportElemenToPosition(collision);
        }
    }
}
