using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    // Start is called before the first frame update

    float speed = 50f;
    float pspeed = 2f;
    Vector3 input;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
        transform.position +=  Vector3.forward * Time.deltaTime;
        print(transform.position);
    }
}
