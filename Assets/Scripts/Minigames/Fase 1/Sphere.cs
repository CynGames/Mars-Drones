using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] Transform VidrioTransform;
    [SerializeField] Vector2 TargetPosition;

    [SerializeField] float delayTimer = .1f;
    [SerializeField] float lerpTimer;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                delayTimer -= Time.deltaTime;

                if (delayTimer < 0)
                {
                    TargetPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                    lerpTimer += Time.deltaTime;

                    Rotation();
                }
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                delayTimer = .1f;
            }
        }
        else if (Input.GetMouseButton(1))
        {
            delayTimer -= Time.deltaTime;

            if (delayTimer < 0)
            {
                TargetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                lerpTimer += Time.deltaTime;

                Rotation();
            }
        }
        else
        {
            lerpTimer = 0;
        }


    }

    public void Rotation()
    {
        Vector2 dir = (TargetPosition - (Vector2)VidrioTransform.transform.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        VidrioTransform.transform.rotation = Quaternion.Lerp(VidrioTransform.transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 0.1f);
    }
}