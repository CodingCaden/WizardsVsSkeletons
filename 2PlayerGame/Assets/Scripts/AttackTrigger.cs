using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public int dmg = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger != false && collision.CompareTag("Enemy"))
            {
            collision.SendMessageUpwards("Damage", dmg);
            }
    }
}
