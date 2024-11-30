using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour
{

    [SerializeField] private GameObject prefabBall;
    [SerializeField] private float shotDellay = 5f;
    [SerializeField] private ParticleSystem fire;

    private float timer = 0;
    private bool isShot = false;
    private int ballDamageMin = 5, ballDamageMax = 15;
    private Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        timer = shotDellay;
        spawnPoint = transform.GetChild(0).position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShot)
        {
            if (timer > 0) timer -= Time.deltaTime;
            else
            {
                timer = shotDellay;
                ShotBall();
            }
        }
    }

    private void ShotBall()
    {
        spawnPoint = transform.GetChild(0).position;
        Vector3 direction = spawnPoint - transform.position;
        //Debug.Log($"(spawnPoint = {spawnPoint}) - (cannonPos = {transform.position})   =>    ( direction = {direction} )");
        int damage = Random.Range(ballDamageMin, ballDamageMax);
        GameObject ball = Instantiate(prefabBall, spawnPoint, Quaternion.identity);
        ball.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        CannonBall cb = ball.GetComponent<CannonBall>();
        if (cb != null)
        {
            direction.y = 0.1f;
            direction.x += Random.Range(-0.01f, 0.01f);
            cb.SetDamageAndDirection(damage, direction);
            fire.Play();
        }
        Destroy(ball, 5f);
    }

    public void SetShot(bool zn)
    {
        isShot = zn;
    }

    public void SetDamageLimit(int damageMin = 5, int damageMax = 15)
    {
        ballDamageMin = damageMin;
        ballDamageMax = damageMax;
    }
}
