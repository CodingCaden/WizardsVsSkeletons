using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NPCHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health = 100f;
    public Animator anim;
    public HealthbarBehavior healthbar;
    private void Start()
    {
        
        health = maxHealth;
        anim.GetComponent("Animator");
        healthbar.SetHealth(health, maxHealth);
    }

    private void Update()
    {
        

        if (health <= 0)
        {
            anim.ResetTrigger("Damage");
            anim.SetTrigger("Die");
            Destroy(gameObject, 1);

        }

    }


    public void Damage(int damage)
    {
        health -= damage;
        anim.SetTrigger("Damage");
        healthbar.SetHealth(health, maxHealth);

    }



}