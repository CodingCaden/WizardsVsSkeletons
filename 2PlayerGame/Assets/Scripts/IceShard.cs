using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShard : MonoBehaviour
{
    public int dmg = 10;
    private void Awake()
    {
        Destroy(gameObject, 3f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == true && collision.CompareTag("Enemy"))
        {
            collision.SendMessageUpwards("Damage", dmg);
        }
    }
}
