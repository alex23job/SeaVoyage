using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForOpenPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
        }
    }
}
