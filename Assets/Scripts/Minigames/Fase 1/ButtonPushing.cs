using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPushing : MonoBehaviour
{
    [SerializeField] Sprite ReleasedButton;
    [SerializeField] Sprite PressedButton;
    [SerializeField] Transform target;

    Image Image;
    public bool isReadyToPush = true;

    private void Awake()
    {
        Image = Image ?? GetComponent<Image>();
    }

    public void OnPress()
    {
        if (isReadyToPush)
        {
            isReadyToPush = false;
            Image.sprite = PressedButton;
            Sphere_Phase_Spawner.Instance.Shoot(target);
        }
    }

    public void OnReleased()
    {
        if (!isReadyToPush)
        {
            isReadyToPush = true;
            Image.sprite = ReleasedButton;
        }
    }
    
    public void OnConvoStart()
    {
        isReadyToPush = false;
    }

    public void OnConvoEnd()
    {
        isReadyToPush = true;
    }
}
