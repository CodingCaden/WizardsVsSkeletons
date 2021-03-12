using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    private Transform Player1pos;
    private Transform Player2pos;
    public float speed = 2f;
    public Animator anim;
    public Rigidbody2D rb;
    public bool InRange1 = false;
    public bool InRange2 = false;
    public bool facingRight = false;
    public bool Frozen = false;

    void Start()
    {
        try
        {
            Player1pos = GameObject.FindGameObjectWithTag("Player1").transform;
            Player2pos = GameObject.FindGameObjectWithTag("Player2").transform;
        }
        catch { }
        
    }
    void Update()
    {
        if (InRange1 == true && Frozen == false)
        {
            if (Player1pos != null)
            {
                Vector3 direction = (Player1pos.transform.position - transform.position).normalized;
                transform.position = Vector2.MoveTowards(transform.position, Player1pos.position, speed * Time.deltaTime);
                if (Player1pos.transform.position.x > gameObject.transform.position.x && facingRight)
                    Flip();
                if (Player1pos.transform.position.x < gameObject.transform.position.x && !facingRight)
                    Flip();
            }
            
        }
       else if (InRange2 == true && Frozen == false)
        {
            if (Player2pos != null)
            {
                Vector3 direction = (Player2pos.transform.position - transform.position).normalized;
                transform.position = Vector2.MoveTowards(transform.position, Player2pos.position, speed * Time.deltaTime);
                if (Player2pos.transform.position.x > gameObject.transform.position.x && facingRight)
                    Flip();
                if (Player2pos.transform.position.x < gameObject.transform.position.x && !facingRight)
                    Flip();
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            Debug.Log("Collided!");
            anim.SetBool("IsFollowing", true);
            InRange2 = false;
            InRange1 = true;
        }else if (collision.tag == "Player2")
        {
           Debug.Log("Collided!");
           anim.SetBool("IsFollowing", true);
            InRange1 = false;
           InRange2 = true;
        }

    }

    void Flip()
    {

        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }
    public GameObject FindClosestPlayer()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
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
    public void Freeze(bool isfrozen)
    {
        if (isfrozen == true)
        {
            Frozen = true;
        }
        else if (isfrozen == false)
        {
            Frozen = false;
        }
    }
}
