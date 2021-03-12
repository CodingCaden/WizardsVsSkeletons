using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class track : MonoBehaviour
{
    public Transform player1, player2;
    private float trackSpeed = 10;
    void SetCameraPos()
    {
        try
        {
            Vector3 middle = (player1.position + player2.position) * 0.5f;
            GetComponent<Camera>().transform.position = new Vector3(
                middle.x,
                middle.y,
                GetComponent<Camera>().transform.position.z);
        }
        catch (MissingReferenceException e)
        {
            if (player1.gameObject == null)
            {
                Vector3 middle = (player2.position);
                GetComponent<Camera>().transform.position = new Vector3(
                    middle.x,
                    middle.y,
                    GetComponent<Camera>().transform.position.z);
            }
            if (player2.gameObject == null)
            {
                Vector3 middle = (player1.position);
                GetComponent<Camera>().transform.position = new Vector3(
                    middle.x,
                    middle.y,
                    GetComponent<Camera>().transform.position.z);
            }
        }
        
    }
    void Update()
    {
        SetCameraPos();
    }
    //public GameObject target;
    //private float trackSpeed = 10;



    //Track target
    //void LateUpdate()
    //{

    //    float x = IncrementTowards(transform.position.x, target.transform.position.x, trackSpeed);
    //    float y = IncrementTowards(transform.position.y, target.transform.position.y, trackSpeed);
    //    transform.position = new Vector3(x, y, transform.position.z);

    //}

    //Increase n towards target by speed
    //private float IncrementTowards(float n, float target, float a)
    //{
    //    if (n == target)
    //    {
    //        return n;
    //    }
    //    else
    //    {
    //        float dir = Mathf.Sign(target - n); // must n be increased or decreased to get closer to target
    //        n += a * Time.deltaTime * dir;
    //        return (dir == Mathf.Sign(target - n)) ? n : target; // if n has now passed target then return target, otherwise return n
    //    }
    //}
}