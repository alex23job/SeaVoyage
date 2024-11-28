using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float Speed = 20;

    private Rigidbody rb;

    private void Awake()
    {
        rb = transform.gameObject.GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //rb = transform.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDamageAndDirection(int dm, Vector3 direction)
    {
        //Debug.Log($"sdad dm={dm} dir={direction}  rb={rb}");
        damage = dm;
        Speed += Random.Range(-0.5f, 0.5f);
        if (rb != null) rb.AddForce(direction * Speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ship"))
        {
            Destroy(transform.gameObject);
        }
    }
}
