using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    void Start()
    {
        
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            Shoot();
        }


    }

    void Shoot()
    {

        GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);

    }

}
