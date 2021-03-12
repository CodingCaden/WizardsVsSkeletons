using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpells : MonoBehaviour
{
    //ScriptNecessities
    public Transform FirePoint;
    public float bulletForce = 20f;
    public Transform playerpos;
    //CoolDownTimers
    public float CooldownTime = .7f;
    public float NextFireTime = 0;
    public float SCooldownTime = 5f;
    public float FCooldownTime = 15f;
    //PreFabs
    public GameObject ShardPrefab;
    public GameObject CrabPrefab;
    public GameObject AuraPrefab;


    void Start()
    {


    }



    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Comma))
        {

            if (Time.time > NextFireTime)
            {
                Shoot();
                NextFireTime = Time.time + CooldownTime;
            }

        }
        if (Input.GetKeyDown(KeyCode.Period))
        {
            if (Time.time > NextFireTime)
            {
                Summon();
                NextFireTime = Time.time + SCooldownTime;
            }
        }
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            if (Time.time > NextFireTime)
            {
                HealFreeze();
                NextFireTime = Time.time + FCooldownTime;
            }
        }




    }

        void Shoot()
        {

            GameObject bullet = Instantiate(ShardPrefab, FirePoint.position, FirePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);

        }


        void Summon()
        {
        var SnowCrab = Instantiate(CrabPrefab, playerpos.position, playerpos.rotation);

        }


        void HealFreeze()
        {
        var HealFreezeAura = Instantiate(AuraPrefab, playerpos.position, playerpos.rotation);
        }
    IEnumerator ShootShard(float time)
    {

        Shoot();

        yield return new WaitForSeconds(time);

        Shoot();
    }
}
