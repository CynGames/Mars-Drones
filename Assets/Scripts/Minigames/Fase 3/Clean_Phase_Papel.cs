using CrunchTools.AudioSystem;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clean_Phase_Papel : Clean_Phase_Dirt_Element
{
    [SerializeField] RecallLight RecallLight;

    Vector2 startingPos;
    BoxCollider2D boxCollider;
    CircleCollider2D circleCollider;
    Rigidbody2D Rb;
    SpriteRenderer Sren;

    private void Start()
    {
        startingPos = transform.position;

        boxCollider = boxCollider ?? GetComponent<BoxCollider2D>();
        circleCollider = circleCollider ?? GetComponent<CircleCollider2D>();
        Rb = Rb ?? GetComponent<Rigidbody2D>();
        Sren = Sren ?? GetComponent<SpriteRenderer>();
    }

    public void CleanUp(Vector2 targetPos)
    {
        ColliderEnabler(false);

        transform.DOMove(targetPos, 3).SetEase(Ease.InExpo).OnComplete(AddScore);
        transform.DORotate(Vector3.forward * 1500, 3, RotateMode.FastBeyond360).SetEase(Ease.InExpo);
        transform.DOScale(Vector2.zero, 3.5f).SetEase(Ease.InExpo);
    }

    private void ColliderEnabler(bool state)
    {
        boxCollider.enabled = state;
        circleCollider.enabled = state;
    }

    void AddScore()
    {
        AudioManager.Instance.PlaySound2D("Exito");

        Clean_Phase_Manager.Instance.ElementsCleaned++;
    }

    protected override void CorrectToolInRange()
    {
        boxCollider.isTrigger = false;
    }

    protected override void CorrectToolInStay()
    {
        return;
    }

    protected override void IncorrectToolInRange()
    {
        boxCollider.isTrigger = true;
    }

    public void InstanciateRecallLight()
    {
        ColliderEnabler(false);

        RecallLight recallLight = Instantiate(RecallLight, transform.position, Quaternion.identity).GetComponent<RecallLight>();
        recallLight.RecallPosition = startingPos;

        Sren.DOFade(0, .15f).OnComplete(ResetState);
    }

    void ResetState()
    {
        transform.position = startingPos;
        Rb.velocity = Vector2.zero;

        Sren.DOFade(1, .15f).SetDelay(1);

        ColliderEnabler(true);
    }
}
