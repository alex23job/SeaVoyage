using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniShipControl : MonoBehaviour
{
    [SerializeField] private GameObject[] cannonsLeft;
    [SerializeField] private GameObject[] cannonsRight;
    [SerializeField] private GameObject[] cannonsBack;
    [SerializeField] private float shotDelay = 5f;
    [SerializeField] private Vector3[] points;
    [SerializeField] private float MoveSpeed = 5f;

    private float timer;
    /// <summary>
    /// режим стрельбы : 0 - нет стрельбы, 1 - левый борт, 2 - правый борт, 3 - корма
    /// </summary>
    private int playShoting = 0;
    private bool isMove = false;
    private Vector3 target;
    private int currentPointIndex = 0;
    private int hitPoints = 100;

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
            {
                currentPointIndex++;
                if (points.Length > 0) currentPointIndex %= points.Length;
                target = points[currentPointIndex];
            }
            else
            {
                Vector3 delta = target - transform.position;

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(delta), 10 * Time.deltaTime);

                transform.Translate(delta.normalized * MoveSpeed * Time.deltaTime, Space.World);

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
        switch(playShoting)
        {
            case 1:
                ShotLeft(true);
                ShotRight(false);
                ShotBack(false);
                break;
            case 2:
                ShotLeft(false);
                ShotRight(true);
                ShotBack(false);
                break;
            case 3:
                ShotLeft(false);
                ShotRight(false);
                ShotBack(true);
                break;
        }
    }
    private void ShotLeft(bool isShoting)
    {
        foreach (GameObject cannon in cannonsLeft)
        {
            cannon.GetComponent<CannonControl>().SetShot(isShoting);
        }
    }
    private void ShotRight(bool isShoting)
    {
        foreach (GameObject cannon in cannonsRight)
        {
            cannon.GetComponent<CannonControl>().SetShot(isShoting);
        }
    }
    private void ShotBack(bool isShoting)
    {
        foreach (GameObject cannon in cannonsBack)
        {
            cannon.GetComponent<CannonControl>().SetShot(isShoting);
        }
    }
}
