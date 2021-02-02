using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sphere_Phase_Spawner : Spawner
{
    public static Sphere_Phase_Spawner Instance;

    public float Firepower;
    public bool readyToLoad = true;

    [SerializeField] TMPro.TMP_Text ScreenText;
    [SerializeField] GameObject LoadedObject;

    protected override void Awake()
    {
        base.Awake();

        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    protected override void Update()
    {
        if (isEmpty)
        {
            if (QueueAssembler.QueuedElements.Count > 0)
            {
                isEmpty = false;
                StartCoroutine(SpawnObject());
            }
            else
            {
                ScreenText.text = "VACIO";
                LoadedObject = null;
            }
        }
    }

    protected override IEnumerator SpawnObject()
    {
        string goName = QueueAssembler.QueuedElements.Peek().ToString().Replace("(UnityEngine.GameObject)", "").Trim();
        GameObject go = null;

        readyToLoad = false;

        SpawnMechanism(goName, ref go);

        while (readyToLoad == false)
        {
            yield return null;
        }

        if (QueueAssembler.QueuedElements.Count > 0)
        {
            StartCoroutine(SpawnObject());
        }
        else
        {
            isEmpty = true;
        }
    }

    protected override void SpawnMechanism(string goName, ref GameObject go)
    {
        if (QueueAssembler.QueuedElements.Peek().scene.IsValid())
        {
            go = QueueAssembler.QueuedElements.Dequeue();
        }
        else
        {
            //Sino instanciarlo y cachearlo
            go = Instantiate(QueueAssembler.QueuedElements.Dequeue());

            if (Sphere_Phase_Manager.Instance.isThisPhase2)
            {
                go.AddComponent<Arrange_Phase_Element>();
            }
            else
            {
                go.AddComponent<Sphere_Phase_Element_Behaviour>();
            }

            go.GetComponent<BoxCollider2D>().edgeRadius = 0;
            go.GetComponent<AdditionalData>().InitObjectString();
        }

        //Si el objeto cacheardo no es nulo, moverlo a la posicion correcta.
        if (go)
        {
            go.name = goName;
            LoadedObject = go;
            SpawnLocation.PositionElement(go);
        }

        if (Sphere_Phase_Manager.Instance.isThisPhase2)
        {
            ScreenText.text = go.GetComponent<AdditionalData>().StringedSecType;
        }
        else
        {
            ScreenText.text = go.GetComponent<AdditionalData>().StringedType;
        }
    }

    public void Shoot(Transform target)
    {
        Vector2 direction = (target.transform.position - LoadedObject.transform.position);

        LoadedObject.GetComponent<Rigidbody2D>().AddForce(direction * Firepower);
        LoadedObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        LoadedObject.AddComponent<CircleCollider2D>();

        readyToLoad = true;
    }
}