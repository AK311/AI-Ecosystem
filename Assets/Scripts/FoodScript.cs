using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    AgentBehaviour agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInParent<AgentBehaviour>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Food"))
        {
            agent.IncrementFoodCount();
            Destroy(collider.gameObject);
            agent.SetPositionToMoveTowards(null);
        }       
    }

}
