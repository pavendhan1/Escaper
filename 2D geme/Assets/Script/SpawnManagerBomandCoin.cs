using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerBomandCoin : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;

 
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
    
    }

    
    void SpawnObjects ()
    {
       
        Vector2 spawnLocation = new Vector2(174, Random.Range(7.5f, 9.46f));
        int index = Random.Range(0, objectPrefabs.Length);

     
     
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
       

    }
}
