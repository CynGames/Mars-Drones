using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPushing : MonoBehaviour
{
    [SerializeField] Sprite ReleasedButton;
    [SerializeField] Sprite PressedButton;
    [SerializeField] Transform target;

    Image Image;
    bool isReadyToPush;

    private void Awake()
    {
        Image = Image ?? GetComponent<Image>();
    }

    public void OnPress()
    {
        if (isReadyToPush == true)
        {
            isReadyToPush = false;
            Image.sprite = PressedButton;
            Sphere_Phase_Spawner.Instance.Shoot(target);
        }
    }

    public void OnReleased()
    {
        if (isReadyToPush == false)
        {
            isReadyToPush = true;
            Image.sprite = ReleasedButton;
        }
    }
    
}
