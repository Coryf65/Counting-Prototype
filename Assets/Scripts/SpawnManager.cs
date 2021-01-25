using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  This Class will spawn all objects being dropped by 
///  The food drop Tower
/// </summary>
public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] foods = null;
    //[SerializeField] private float spawnDelay = 0.5f;
    //[SerializeField] private float spawnInterval = 0.5f;
    [SerializeField] private int totalFoodsToSpawn = 20;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObjects()
    {
        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(Random.Range(-2, 2), Random.Range(12, 19), Random.Range(-2, 2));
        
        // If game is still active, spawn new object
        for (int i = 0; i < totalFoodsToSpawn; i++)
        {
            new WaitForSeconds(Random.Range(3f, 10f));
            Instantiate(foods[GetRandomFood()], spawnLocation, foods[GetRandomFood()].transform.rotation);
        }           
    }

    int GetRandomFood()
    {
        return Random.Range(0, foods.Length);
    }
}
