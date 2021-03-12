using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowCrabFollow : MonoBehaviour
{
    private Transform Enemypos;
    public float speed = 2f;
    public bool InRangeE = false;
    public bool InRangeP = false;
    public bool facingRight = false;
    public Animator anim;
    Transform Playerpos;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            Enemypos = FindClosestEnemy().transform;
        }
        catch
        {
            
        }
            
        

        Playerpos = FindClosestPlayer().transform;
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (InRangeE == true)
        {
            if(Enemypos != null)
            {
                Vector3 direction = (Enemypos.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, Enemypos.position, speed * Time.deltaTime);
            if (Enemypos.transform.position.x > gameObject.transform.position.x && facingRight)
                Flip();
            if (Enemypos.transform.position.x < gameObject.transform.position.x && !facingRight)
                Flip();
            }
            
        }else if (InRangeP == true)
        {
            if(Playerpos != null)
            {
                if (Vector2.Distance(transform.position, Playerpos.position) > 1)
                {
                    Vector3 direction = (Playerpos.transform.position - transform.position).normalized;
                    transform.position = Vector2.MoveTowards(transform.position, Playerpos.position, speed * Time.deltaTime);
                    if (Playerpos.transform.position.x > gameObject.transform.position.x && facingRight)
                        Flip();
                    if (Playerpos.transform.position.x < gameObject.transform.position.x && !facingRight)
                        Flip();
                }
            }
            
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Collided!");
            anim.SetBool("IsFollowing", true);
            InRangeE = true;
        }else if (collision.tag == "Player1")
        {
            Debug.Log("Collided!");
            anim.SetBool("IsFollowing", true);
            InRangeP = true;
        }

    }
    void Flip()
    {
        //here your flip funktion, as example
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }


    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;

        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
    public GameObject FindClosestPlayer()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player1");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
