using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(ObjectLibrary))]
public class QueueAssembler : MonoBehaviour
{
    public Queue<GameObject> QueuedElements = new Queue<GameObject>();

    [SerializeField] List<GameObject> randomizedElements = new List<GameObject>();
    ObjectLibrary objectLibrary;

    private void Awake()
    {
        objectLibrary = objectLibrary ?? FindObjectOfType<ObjectLibrary>();
    }

    private void Start()
    {
        GetElementsFromLib();

        randomizedElements = ListUtils.ShuffleList(randomizedElements);

        FillTheQueue();
    }

    private void GetElementsFromLib()
    {
        foreach (var obj in objectLibrary.Entries)
        {
            for (int i = 0; i < obj.amount; i++)
            {
                randomizedElements.Add(obj.interactableObject);
            }
        }
    }

    void FillTheQueue()
    {
        foreach (GameObject element in randomizedElements)
        {
            QueuedElements.Enqueue(element);
        }
    }
}