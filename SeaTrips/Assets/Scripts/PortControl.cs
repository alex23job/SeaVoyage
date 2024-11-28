using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortControl : MonoBehaviour
{
    [SerializeField] private GameObject[] cannons;
    [SerializeField] private GameObject[] cranes;

    private float timer = 5f;
    private bool isShotCannons = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
        else
        {
            timer = 5f;
            isShotCannons = !isShotCannons;
            foreach(GameObject cannon in cannons)
            {
                cannon.GetComponent<CannonControl>().SetShot(isShotCannons);
            }
        }
    }
}
