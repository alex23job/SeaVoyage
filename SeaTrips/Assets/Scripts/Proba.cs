using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proba : MonoBehaviour
{
    [SerializeField] private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(target);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 10 * Time.deltaTime);
    }
}
