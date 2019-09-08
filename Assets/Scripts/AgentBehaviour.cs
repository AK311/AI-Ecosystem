using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBehaviour : MonoBehaviour
{
    public Transform agent; //sprite for showing size change
    public CircleCollider2D senseTrigger; // the sense trigger through which agent detects food
    //All the Genes
    float speed = 5f;
    float size = 1.5f;
    float sense = 5f;
    //----------
    bool ifChasingFood;
    int foodCollected; // to count the no of food consumed;
    Vector2? moveTowardsPosition; //Create a Optional Vector2 means can also have null value 
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void IntializeAgent(float speed,float size,float sense)
    {
        this.speed = speed;
        this.size = size;
        agent.localScale = Vector3.one * size;
        this.sense = senseTrigger.radius = sense;
        foodCollected = 0;
        moveTowardsPosition = null;       
    }
    // Update is called once per frame
    void Update()
    {
        MoveTowardsPosition();      
    }

    public bool IfChasingFood()
    {
        return ifChasingFood;
    }

    public void SetPositionToMoveTowards(Vector2? position)
    {
        if(position.HasValue)
        { 
            moveTowardsPosition = position.Value;
            ifChasingFood = true;
        }
        else
        {
            moveTowardsPosition = null;  
            ifChasingFood = false;
        }   
    }

    void MoveTowardsPosition()
    {
        if(moveTowardsPosition.HasValue)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,moveTowardsPosition.Value,speed * Time.deltaTime);
            if(Vector3.Distance(transform.localPosition,moveTowardsPosition.Value)<0.5f)
                moveTowardsPosition = null;
        }
        else
        {
            moveTowardsPosition = EcoSystemController.instance.GetRandomPositionOnPlane();
            ifChasingFood = false;
        }
    }

    public void IncrementFoodCount()
    {
        foodCollected++;
    }

    public (float speed,float size,float sense) GetChromosomes()
    {
        return (speed,size,sense);       
    }
}
