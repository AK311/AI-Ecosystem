using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    // Start is called before the first frame update
     float speed = 50f;

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Sphere" || other.name == "Cube")
            Destroy(gameObject);
    }
}
