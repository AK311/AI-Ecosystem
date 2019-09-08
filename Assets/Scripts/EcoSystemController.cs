using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EcoSystemController : MonoBehaviour
{
    public static EcoSystemController instance {get;set;} // for making a Singleton
    [Header("Food")]
    public int foodCount; // No of food to be generated in the instance
    public Transform foodParent;
    public GameObject foodPrefab;
    List<GameObject> foodCollection;
    
    [Header("Region")]
    public float regionWidth; // width of the working plane

    [Header("AgentProperties")] //min and max values of respective genes
    public int agentCount;
    public Transform agentParent;
    public GameObject agentPrefab;
    public Vector2 speed;
    public Vector2 size;
    public Vector2 sense;
    public enum GeneType {speed,size,sense};
    List<GameObject> agentCollection;

    public enum IntialPopulationType {uniform,uniformWithMutation,categorizedWithMutation};
    [Header("Intialization")]
    public IntialPopulationType populationType;
    public Vector3[] populationSamples; // used in categorizedwithMutation;
    
    [Range(0f,1f)]
    public float mutationFactor = 0.1f;

    void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        foodCollection = new List<GameObject>();
        agentCollection = new List<GameObject>();
        GenerateFood();
        GenerateIntialPopulation();
    }

    void GenerateIntialPopulation()
    {
        Vector2 tempPosition;
        GameObject temp;
        float mutation = 0f;
        int sample = 0;
        float tempX,tempY,tempZ;
        for(int i=0;i<agentCount;i++)
        {
            switch(populationType)
            { 
                case IntialPopulationType.uniformWithMutation:
                    mutation = mutationFactor;
                    sample = 0;
                break;
                case IntialPopulationType.categorizedWithMutation:
                    mutation = mutationFactor;
                    sample = Random.Range(0,populationSamples.Length);  
                break;
                default:
                    mutation = 0f;
                    sample = 0;
                break;          
            }
            tempPosition = GetAgentInstantiationPosition();
            temp = Instantiate(agentPrefab,tempPosition,Quaternion.identity);
            temp.transform.parent = agentParent;
            tempX = populationSamples[sample].x + Random.Range(-mutation,mutation);
            tempY = populationSamples[sample].y + Random.Range(-mutation,mutation);
            tempZ = populationSamples[sample].z + Random.Range(-mutation,mutation);
            temp.GetComponent<AgentBehaviour>().IntializeAgent(tempX,tempY,tempZ);
            agentCollection.Add(temp); 
        }
    }

    Vector2 GetAgentInstantiationPosition()
    {
        Vector2 start,end;
        switch(Random.Range(0,4))
        {
            case 0: 
                start = new Vector2(-regionWidth,regionWidth);
                end = new Vector2(regionWidth,regionWidth);
            break;
            case 1:
                start = new Vector2(regionWidth,regionWidth);
                end = new Vector2(regionWidth,-regionWidth);
            break;
            case 2:
                start = new Vector2(regionWidth,-regionWidth);
                end = new Vector2(-regionWidth,-regionWidth);
            break;
            default:
                start = new Vector2(-regionWidth,-regionWidth);
                end = new Vector2(-regionWidth,regionWidth);
            break;   
        }
        return Vector2.Lerp(start,end,Random.value);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateFood()
    {
        for(int i=0;i<foodCount;i++)
        {
            Vector2 position = GetRandomPositionOnPlane();
            GameObject temp = Instantiate(foodPrefab,position,Quaternion.identity);
            temp.transform.parent = foodParent;
            foodCollection.Add(temp);   
        }
    }

    public Vector2 GetRandomPositionOnPlane()
    {
        return new Vector2(Random.Range(-regionWidth,regionWidth),Random.Range(-regionWidth,regionWidth));
    }

    public float GetNormalizedValue(GeneType type,float value)
    {
        switch(type)
        {
            case GeneType.speed:
                return value/(speed.y-speed.x);
            case GeneType.size:
                return value/(size.y-size.x);
            case GeneType.sense:
                return value/(sense.y-sense.x);        
        }
        return 0f;
    }

    public float GetScaledValue(GeneType type,float value)
    {switch(type)
        {
            case GeneType.speed:
                return speed.x + value*(speed.y-speed.x);
            case GeneType.size:
                return size.x + value*(size.y-size.x);
            case GeneType.sense:
                return sense.x + value*(sense.y-sense.x);        
        }
        return 0f;
    }
}
