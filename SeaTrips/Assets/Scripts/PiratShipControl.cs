using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiratShipControl : MonoBehaviour
{
    [SerializeField] private GameObject[] cannonsLeft;
    [SerializeField] private GameObject[] cannonsRight;
    [SerializeField] private GameObject[] cannonsBack;
    [SerializeField] private float shotDelay = 5f;
    [SerializeField] private Vector3[] points;
    [SerializeField] private float MoveSpeed = 5f;

    private float timer;
    private int playShoting = 0;
    private bool isMove = false;
    private Vector3 target;
    private int currentPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = shotDelay;
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playShoting > 0)
        {
            if (timer > 0) timer -= Time.deltaTime;
            else
            {
                timer = shotDelay;
                Shoting();
            }
        }
        if (isMove)
        {
            if (Vector3.Distance(transform.position, target) <= 0.4f)
            //if (transform.position == target)
            {
                currentPointIndex++;
                if (points.Length > 0) currentPointIndex %= points.Length;
                target = points[currentPointIndex];
            }
            else
            {
                Vector3 delta = target - transform.position;
                //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(delta), 10 * Time.deltaTime);
                //transform.rotation = Quaternion.LookRotation(delta.normalized);
                //Vector3 newDirection = Vector3.RotateTowards(transform.forward, -delta.normalized * 90f, 10 * Time.fixedDeltaTime, 0);
                //Vector3 newDirection = Vector3.RotateTowards(transform.forward, delta, 10 * Time.fixedDeltaTime, 0);
                //transform.rotation = Quaternion.LookRotation(newDirection);

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(delta), 10 * Time.deltaTime);
                //print($"tr.r={transform.rotation}   delta={delta}");
                //float rotY = transform.rotation.eulerAngles.y + 10 * Time.deltaTime;
                //print($"y={transform.rotation.eulerAngles.y}  rotY={rotY}");
                //transform.rotation = Quaternion.Euler(new Vector3(0, rotY, 0));

                transform.Translate(delta.normalized * MoveSpeed * Time.deltaTime, Space.World);

                /*if (delta.magnitude > 0.05f)
                {
                    Vector3 movement = delta.normalized * MoveSpeed * Time.deltaTime;

                    if (movement.magnitude <= delta.magnitude)
                    {
                        transform.position += movement;
                    }
                    else
                    {
                        transform.position = target;
                    }
                }
                else
                {
                    transform.position = target;
                }*/
            }
        }
    }

    public void SetMove(bool zn)
    {
        isMove = zn;
    }

    public void SetShoting(int zn)
    {
        playShoting = zn;
    }

    public void SetPoints(Vector3[] arr)
    {
        points = arr;
        target = points[0];
        transform.position = target;
    }

    private void Shoting()
    {

    }
}
