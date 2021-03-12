using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == true && collision.CompareTag("Player1") || collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Renderer>().material.color = Color.blue;
            collision.SendMessageUpwards("Freeze", true);
            collision.SendMessageUpwards("Heal", 50, SendMessageOptions.DontRequireReceiver);
            StartCoroutine(Wait(collision));
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == true && collision.CompareTag("Player1") || collision.CompareTag("Enemy"))
        {
            try
            {
                collision.gameObject.GetComponent<Renderer>().material.color = Color.white;
                collision.SendMessageUpwards("Freeze", false, SendMessageOptions.DontRequireReceiver);
            }
            catch
            {

            }
            

        }
    }


    IEnumerator Wait(Collider2D collision)
    {
        yield return new WaitForSeconds(2.5f);
        try
        {
            collision.gameObject.GetComponent<Renderer>().material.color = Color.white;
            collision.SendMessageUpwards("Freeze", false);
        }
        catch
        {

        }

    }

}
