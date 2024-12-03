using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiratShipControl : MonoBehaviour
{
    [SerializeField] private GameObject[] cannonsLeft;
    [SerializeField] private GameObject[] cannonsRight;
    [SerializeField] private GameObject[] cannonsBack;
    [SerializeField] private float shotDelay = 5f;
    [SerializeField] private Vector3[] points;
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private float DownSpeed = 2f;
    [SerializeField] private string nameShip;
    [SerializeField] private Image imgHP;

    [SerializeField] private float radius = 5f;
    [SerializeField] private LayerMask layerMask;

    public string NameShip { get { return nameShip; } }
    private float timer;
    /// <summary>
    /// режим стрельбы : 0 - нет стрельбы, 1 - левый борт, 2 - правый борт, 3 - корма
    /// </summary>
    private int playShoting = 0;
    private bool isMove = false;
    private bool isSinking = false;
    private Vector3 target;
    private int currentPointIndex = 0;
    private int currentHP = 100;
    private int maxHP = 100;

    // Start is called before the first frame update
    void Start()
    {
        timer = shotDelay;
        target = transform.position;
        playShoting = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSinking)
        {
            isMove = false;
            if (transform.position.y > -20) transform.Translate(Vector3.down * DownSpeed * Time.deltaTime, Space.World);
            return;
        }
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

                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(delta), 10 * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(delta), Time.deltaTime);
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

    public void SetNameShip(string nm)
    {
        nameShip = nm;
    }

    public void SetMove(bool zn)
    {
        isMove = zn;
    }
    public void ChangeHP(int zn)
    {
        int tmp = currentHP + zn;
        if (tmp > 0)
        {
            currentHP = tmp;
        }
        else
        {   //  уничтожен - тонем
            currentHP = 0;
            isSinking = true;
        }
        ViewHP();
    }

    private void ViewHP()
    {
        if (imgHP != null && maxHP != 0)
        {
            imgHP.fillAmount = (float)currentHP / (float)maxHP;
        }
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
        Collider[] colls = Physics.OverlapSphere(transform.position, radius, layerMask);
        if (colls.Length > 0)
        {
            foreach (Collider col in colls)
            {
                Vector3 direction = col.transform.position - transform.position;
                float angle = Mathf.Atan2(direction.z, direction.x);
                angle *= (180f / Mathf.PI);
                if (angle > 0 && angle < 135f) playShoting = 2;
                else if (angle > 135f && angle < 225f) playShoting = 3;
                else playShoting = 1;
                Debug.Log($"nameShip={col.gameObject.GetComponent<MiniShipControl>().NameShip}   dir=>{direction}   angle=>{angle}   playShoting=>{playShoting}");
            }
            switch (playShoting)
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
                default:
                    break;
            }
        }
        else
        {
            playShoting = 5;
            ShotLeft(false);
            ShotRight(false);
            ShotBack(false);
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
