using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenseScript : MonoBehaviour
{
    AgentBehaviour agent; 
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInParent<AgentBehaviour>();   
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.CompareTag("Food"))
        {
            if(!agent.IfChasingFood())
                agent.SetPositionToMoveTowards(collider.transform.localPosition);
        }       
    }
}
