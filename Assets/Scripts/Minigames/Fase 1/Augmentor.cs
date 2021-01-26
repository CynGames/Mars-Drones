using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Augmentor : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Sphere_Phase_Element_Behaviour>())
        {
            collision.GetComponent<Rigidbody2D>().velocity *= 2f;
        }
    }
}
