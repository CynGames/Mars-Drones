using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

/// <summary>
/// Desactivar estos elementos los re-asigna al queue
/// 
/// </summary>
public abstract class ElementBehaviour : MonoBehaviour
{
    #region Vars
    public AdditionalData data;
    public bool isBeingDragged;
    public Rigidbody2D Rb;

    [SerializeField] protected GameObject RecallLight;

    protected QueueAssembler queueAssembler;
    protected SpriteRenderer Sren;

    protected bool placed = false;
    protected bool deactivateStay = false;

    #endregion

    #region Automatic Functions
    protected virtual void Awake()
    {
        queueAssembler = queueAssembler ?? FindObjectOfType<QueueAssembler>();
        Sren = Sren ?? GetComponent<SpriteRenderer>();
        Rb = Rb ?? GetComponent<Rigidbody2D>();
        data = data ?? GetComponent<AdditionalData>();
    }

    protected virtual void Start()
    {
        if (RecallLight == null)
            RecallLight = (GameObject)Resources.Load("Lights/ConcealmentLight");
    }

    protected virtual void OnStartDrag()
    {
        isBeingDragged = true;
    }

    protected virtual void OnStopDrag()
    {
        isBeingDragged = false;
    }

    #endregion

    #region UnityEvents

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (deactivateStay)
            return;
    }

    protected virtual void OnEnable()
    {
        deactivateStay = false;
        Rb.gravityScale = 0;
    }

    protected virtual void OnDisable()
    {
        ReturnToQueue();
    }

    protected virtual void Update()
    {
        if (placed == true)
        {
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(GetComponent<Rigidbody2D>());
        }
    }

    #endregion

    #region Try, Move & Queue Return

    public virtual void DespawnAndRecall(Vector2 SpawnPosition, Transform RecallDestination, bool desactivateObject)
    {
        RecallLight recallLight = Instantiate(RecallLight, SpawnPosition, Quaternion.identity).GetComponent<RecallLight>();
        recallLight.RecallDestination = RecallDestination;

        gameObject.SetActive(!desactivateObject);
    }

    protected virtual bool TryPlacementValidity(Placement slot)
    {
        deactivateStay = true;

        //Preguntar si es valido poner este objeto acá
        if (slot.ReturnPlacementValidation(this))
        {
            //valido

            return true;
        }
        else
        {
            //invalido

            DespawnAndRecall(transform.position, RecallManager.Instance.GetMainDestination(), true);

            return false;
        }
    }

    protected virtual void SmoothPlacement(Vector2 target)
    {
        transform.DOMove(target, 1, false).OnComplete(OnCompleteCallback());
    }

    protected virtual TweenCallback OnCompleteCallback()
    {
        Rb.velocity = Vector2.zero;
        
        return null;
    }

    protected virtual void ReturnToQueue()
    {
        if (placed == false)
        {
            if (queueAssembler)
            {
                queueAssembler.QueuedElements.Enqueue(gameObject);
            }
        }
    }

    #endregion
}