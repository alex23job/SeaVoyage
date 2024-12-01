using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasToCamera : MonoBehaviour
{
    [SerializeField] private Canvas shipCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shipCanvas.transform.rotation = Camera.main.transform.rotation;
    }
}
