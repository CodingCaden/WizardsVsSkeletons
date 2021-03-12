using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowCrabScript : MonoBehaviour
{
    public int dmg = 15;
    float damageTime = .5f;
    float currentDamageTime;
    public GameObject Enemy;
    public Animator anim;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger != false && collision.CompareTag("Enemy"))
        {
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                anim.SetBool("Attack", true);
                collision.SendMessageUpwards("Damage", dmg);
                currentDamageTime = 0.0f;
            }
        }
        else
        {
            anim.SetBool("Attack", false);
        }

    }
 
    
}
