using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceControl : MonoBehaviour
{
    [SerializeField] private LevelControl lc;
    [SerializeField] private float force = 12f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnDice()
    {
        Vector3 direction = Vector3.up;
        direction.x = Random.Range(-0.2f, 0.2f);
        direction.z = Random.Range(-0.2f, 0.2f);
        transform.rotation =  Quaternion.Euler(Random.Range(-90f, 90f), Random.Range(-90f, 90f), Random.Range(-90f, 90f));
        rb.AddForce(direction * force, ForceMode.Impulse);
    }
}
