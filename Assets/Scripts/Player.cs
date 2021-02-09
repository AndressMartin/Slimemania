using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;

    public float speed = 5;
    public float gravit;
    public float rotSpeed;

    private float rot;
    private Vector3 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                moveDirection = Vector3.forward * speed;
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                moveDirection = Vector3.zero;
            }

            if (Input.GetKey(KeyCode.S))
            {
                moveDirection = Vector3.forward * speed * -1;
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                moveDirection = Vector3.zero;
            }

        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDirection.y -= gravit * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);
    }
}

