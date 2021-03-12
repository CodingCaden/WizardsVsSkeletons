using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    public bool Frozen = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {

        HandleMove();

    }

        void HandleMove()
        {
        float speed = 4f;
        float moveXaxis = 0f;
        float moveYaxis = 0f;


        if (Input.GetKey(KeyCode.UpArrow) && Frozen == false)
        {
            moveYaxis = +2f;
        }
        if (Input.GetKey(KeyCode.DownArrow) && Frozen == false)
        {
            moveYaxis = -2f;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Frozen == false)
        {
            moveXaxis = -2f;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && Frozen == false)
        {
            moveXaxis = +2f;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        Vector3 moveDir = new Vector3(moveXaxis, moveYaxis).normalized;
        transform.position += moveDir * speed * Time.deltaTime;

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;

        anim.SetFloat("moveY", moveYaxis);
        anim.SetFloat("moveX", moveXaxis);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            anim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }


    }
    public void Freeze(bool isfrozen)
    {
        if (isfrozen == true)
        {
            Frozen = true;
        }else if (isfrozen == false)
        {
            Frozen = false;
        }
    }
}
