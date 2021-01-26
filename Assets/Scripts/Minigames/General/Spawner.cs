using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Se encarga de instanciar/activar objetos y pedirle al transponder que los posicione.
/// </summary>
[RequireComponent(typeof(SpawnLocation))]
[RequireComponent(typeof(QueueAssembler))]
[RequireComponent(typeof(RecallManager))]
public abstract class Spawner : MonoBehaviour
{
    //da la cola de objetos
    [FormerlySerializedAs("queueAssembler")]
    protected QueueAssembler QueueAssembler;

    //da el punto valido de spawn
    [SerializeField] protected SpawnLocation SpawnLocation;

    //flag para la rutina
    protected bool isEmpty = true;

    protected virtual void Awake()
    {
        //agarra referencias
        SpawnLocation = SpawnLocation ?? FindObjectOfType<SpawnLocation>();
        QueueAssembler = QueueAssembler ?? FindObjectOfType<QueueAssembler>();
    }

    protected virtual void Start()
    {
        if (QueueAssembler.QueuedElements.Count > 0)
        {
            StartCoroutine(SpawnObject());
        }
    }

    protected abstract IEnumerator SpawnObject();

    protected abstract void SpawnMechanism(string goName, ref GameObject go);

    protected virtual void Update()
    {
        if (isEmpty)
        {
            if (QueueAssembler.QueuedElements.Count > 0)
            {
                StartCoroutine(SpawnObject());
            }
        }
    }
}