using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Melee : MonoBehaviour
{
    private bool attacking = false;
    private float attackTimer = 0;
    private float attackCd = .5f;
    public Animator anim;

    public Collider2D attackTrigger;

    private void Awake()
    {
        attackTrigger.enabled = false;
        anim.GetComponent("Animator");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !attacking)
        {
            attacking = true;
            attackTimer = attackCd;
            anim.SetTrigger("Attack");

            attackTrigger.enabled = true;
        }


        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
    }
}
