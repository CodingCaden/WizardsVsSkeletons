using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public int damage = 40;
    public GameObject impactEffect;
    public LineRenderer linerenderer;

    void Update()
    {
        if (Input.GetButtonDown("/"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(FirePoint.position, FirePoint.right);

        if (hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

            linerenderer.SetPosition(0, FirePoint.position);
            linerenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            linerenderer.SetPosition(0, FirePoint.position);
            linerenderer.SetPosition(1, FirePoint.position + FirePoint.right * 100);
        }
    }
}
