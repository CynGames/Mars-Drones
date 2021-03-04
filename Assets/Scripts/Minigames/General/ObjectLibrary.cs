using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectLibrary : MonoBehaviour
{
    public InteractableObjDatabase[] Entries;

    [System.Serializable]
    public class InteractableObjDatabase
    {
        public GameObject interactableObject;
        public int amount;
    }
}
