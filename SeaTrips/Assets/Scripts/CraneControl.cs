using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneControl : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"CraneTrigger anim={anim} in trigger enter {other.name}");
        if (other.CompareTag("ship"))
        {
            Debug.Log($"{other.name} in trigger {transform.name}");
            anim.Play("CraneRotation");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"CraneCollision anim={anim} in boxTrigger enter {collision.gameObject.name}");
        if (collision.gameObject.CompareTag("ship"))
        {
            Debug.Log($"{collision.gameObject.name} in trigger {transform.name}");
            anim.Play("CraneRotation");
        }
    }
}
