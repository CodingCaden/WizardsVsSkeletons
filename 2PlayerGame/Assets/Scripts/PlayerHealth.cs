using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float curHealth = 0f;
    float maxHealth = 100f;
    public Animator anim;
    public HealthbarBehavior healthbar;
   

    private void Start()
    {
        curHealth = maxHealth;
        anim.GetComponent("Animator");
    }

     private void Update()
    {
        healthbar.SetHealth(curHealth, maxHealth);
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if(curHealth <= 0)
        {
            Die();
        }

    }

    public void Damage(int damage)
    {
        curHealth -= damage;
        anim.SetTrigger("Damage");
    }

    void Die()
    {

        anim.SetTrigger("Die");
        //Destroy(gameObject, 1);
        //Instead of death player is set inActive
        gameObject.SetActive(false);
    }
    public void Heal(int amountofhealth)
    {
        curHealth = curHealth + amountofhealth;
    }
}
