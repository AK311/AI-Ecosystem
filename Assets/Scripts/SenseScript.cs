using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenseScript : MonoBehaviour
{
    public AgentBehaviour agent; 
   
    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.CompareTag("Food"))
        {
            if(!agent.IfChasingFood())
                agent.SetPositionToMoveTowards(collider.transform.localPosition);
        }       
    }
}
