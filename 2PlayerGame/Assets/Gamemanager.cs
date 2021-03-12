using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if(player1.activeSelf == false && player2.activeSelf == false)
        {
            canvas.SetActive(true);
        }

    }
}
