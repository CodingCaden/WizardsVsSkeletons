using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAttack : MonoBehaviour
{
    public int dmg = 20;
    float damageTime = 1.0f;
    float currentDamageTime;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger != false && collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                collision.SendMessageUpwards("Damage", dmg);
                currentDamageTime = 0.0f;
            }
        }
        
    }
    public void Update()
    {


    }
}
