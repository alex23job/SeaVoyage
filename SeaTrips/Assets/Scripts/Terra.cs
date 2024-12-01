using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terra : MonoBehaviour
{
    [SerializeField] private ParticleSystem waterShot;
    [SerializeField] private GameObject piratShip;
    [SerializeField] private GameObject miniShip;
    [SerializeField] private GameObject corvet;

    private float timer = 1f;
    private int countTime = 0, numCannonsGroup = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (piratShip != null)
        {
            piratShip.GetComponent<PiratShipControl>().SetMove(true);
        }
        if (miniShip != null)
        {
            miniShip.GetComponent<MiniShipControl>().SetMove(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
        else
        {
            timer = 1f;
            if (miniShip.transform.position.x > -30 && miniShip.transform.position.x < 30)
            {
                countTime++;
                if (countTime > 10)
                {
                    corvet.GetComponent<MiniShipControl>().SetShoting(numCannonsGroup + 1);
                    miniShip.GetComponent<MiniShipControl>().SetShoting(numCannonsGroup + 1);
                    countTime = 0;
                    numCannonsGroup++;numCannonsGroup %= 3;
                }
            }
            else countTime = 0;
        }
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
