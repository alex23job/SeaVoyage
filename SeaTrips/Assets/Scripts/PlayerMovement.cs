using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private float rotationRate = 360;

    private Rigidbody rb;
    private float hor, ver;

    private Animator anim;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        //movement = new Vector3(hor, 0, ver);
        //movement *= speed * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.AddForce(movement, ForceMode.Impulse);
        Move(ver);
        Turn(hor);
    }
    private void Move(float input)
    {
        if (input != 0)
        {

            anim.SetFloat("Speed", Mathf.Abs(input) * 5f);
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }
        transform.Translate(Vector3.forward * input * moveSpeed * Time.fixedDeltaTime);//Можно добавить Time.DeltaTime
    }

    private void Turn(float input)
    {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }
}

