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
    public Vector2 speed;
    public Vector2 size;
    public Vector2 sense;
    
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
        GenerateFood();
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

}
