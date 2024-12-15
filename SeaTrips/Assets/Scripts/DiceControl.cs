using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceControl : MonoBehaviour
{
    [SerializeField] private LevelControl lc;
    [SerializeField] private float force = 12f;

    private Rigidbody rb;

    private float timer = 0.25f;
    private bool isTurn = false;
    private Vector3 oldPos;

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
        if (isTurn)
        {
            if (timer > 0) timer -= Time.deltaTime;
            else
            {
                timer = 0.25f;
                if (oldPos != transform.position)
                {
                    oldPos = transform.position;
                }
                else
                {
                    if (lc != null) lc.TranslateCount(GetCount());
                    isTurn = false;
                }
            }
        }
    }

    private int GetCount()
    {
        int res = 0;
        Vector3 rot = transform.rotation.eulerAngles;
        if ((rot.x < 45 || rot.x > 315) && (rot.z < 45 || rot.z > 315)) res = 5;
        if ((rot.x < 45 || rot.x > 315) && (rot.z > 135 && rot.z < 225)) res = 3;
        if ((rot.x < 45 || rot.x > 315) && (rot.z > 45 && rot.z < 135)) res = 2;
        if ((rot.x < 45 || rot.x > 315) && (rot.z > 225 && rot.z < 315)) res = 4;
        if ((rot.x > 45 && rot.x < 135) && (rot.z < 45 || rot.z > 315)) res = 1;
        if ((rot.x > 225 && rot.x < 315) && (rot.z < 45 || rot.z > 315)) res = 6;
        print($"rot=>{rot}  zn=>{res}");
        return res;
    }

    public void TurnDice()
    {
        if (isTurn) return;
        isTurn = true;
        Vector3 direction = Vector3.up;
        direction.x = Random.Range(-0.2f, 0.2f);
        direction.z = Random.Range(-0.2f, 0.2f);
        transform.rotation =  Quaternion.Euler(Random.Range(-150f, 150f), Random.Range(-150f, 150f), Random.Range(-150f, 150f));
        rb.AddForce(direction * force, ForceMode.Impulse);
    }
}
