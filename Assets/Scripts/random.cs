using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;

public class random : MonoBehaviour
{
    // Start is called before the first frame update

    public float delaytimer;
    Vector3 pos;

    void Start()
    {
        getNewPosition(); // get initial targetpos
    }

    void Update()
    {
        delaytimer += Time.deltaTime;

        if (delaytimer > 1) // time to wait 
        {
            getNewPosition(); //get new position every 1 second
            delaytimer = 0f; // reset timer
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, .1f);
    }

    void getNewPosition()
    {
        float x = Random.Range(-10, 10);
        float z = Random.Range(-10, 10);

        pos = new Vector3(x, 0, z);
    }
}
