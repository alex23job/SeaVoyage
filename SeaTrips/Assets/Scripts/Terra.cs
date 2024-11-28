using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terra : MonoBehaviour
{
    [SerializeField] private ParticleSystem waterShot;
    [SerializeField] private GameObject piratShip;
    // Start is called before the first frame update
    void Start()
    {
        if (piratShip != null)
        {
            piratShip.GetComponent<PiratShipControl>().SetMove(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            other.tag = "Untagged";
            ParticleSystem ps = Instantiate(waterShot, other.transform.position, Quaternion.identity);
            ps.Play();
            Destroy(ps.gameObject, 1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            collision.gameObject.tag = "Untagged";
            ParticleSystem ps = Instantiate(waterShot, collision.transform.position, Quaternion.identity);
            ps.Play();
            Destroy(ps.gameObject, 1f);
        }
    }
}
