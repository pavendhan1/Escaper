using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public float obstacleSpawnRate = 2f;
    public GameObject obstaclePrefab;
    public GameObject spawnObj;
    public float speed = 5;
    public bool isSPawn = false;
    public GameObject ZigPoint;
    public GameObject ZigObj;

    //bom
    public GameObject[] objectPrefabs;
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;

    private void Start()
    {

        InvokeRepeating("SpawnObstacle", 0f, obstacleSpawnRate);

        InvokeRepeating("ZigZag", 0f, Random.Range(2, 5));

        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);

    }

    private void Update()
    {


    }

    private void SpawnObstacle()
    {


        float randomX = Random.Range(0f, 12f);
        Vector2 topSpawnPosition = new Vector2(randomX, 10f);
        GameObject spawnObj = Instantiate(obstaclePrefab, topSpawnPosition, Quaternion.identity);


        spawnObj.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0f);


        float randomY = Random.Range(20f, 37f);
        Vector2 bottomSpawnPosition = new Vector2(randomY, -0.89f);
        GameObject spawnObj1 = Instantiate(obstaclePrefab, bottomSpawnPosition, Quaternion.identity);
        spawnObj1.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0f);

        Destroy(spawnObj1, 5);
        Destroy(spawnObj, 5);


    }

    private void ZigZag()
    {
        Instantiate(ZigObj, ZigPoint.transform.position, Quaternion.identity);




    }

    void SpawnObjects()
    {

        Vector2 spawnLocation = new Vector2(198, Random.Range(7.5f, 9.46f));
        int index = Random.Range(0, objectPrefabs.Length);


        Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("L1"))
        {
            isSPawn = true;
        }

    }



}
