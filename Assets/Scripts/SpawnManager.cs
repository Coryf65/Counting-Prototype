using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  This Class will spawn all objects being dropped by 
///  The food drop Tower
/// </summary>
public class SpawnManager : MonoBehaviour
{
    [Header("GameObjects to Spawn")]
    [SerializeField] private GameObject[] foods = null;
    [Header("Spawn Settings")]
    [Tooltip("Number of total objects to spawn.")][Range(1, 100)]
    [SerializeField] private int totalFoodsToSpawn = 20;
    [Tooltip("Location to spawn the GameObjects.")]
    [SerializeField] private Vector3 spawnLocation = new Vector3(2, 19, 2);
    [SerializeField] private bool drawSpawnArea = false;
    
    // how to add a bit of randomness ??
    //[SerializeField] private float x


    private PlayerController playerControllerScript;
    private float respawnTime;

    // Start is called before the first frame update
    void Start()
    {
        
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        StartCoroutine(FoodWave());
    }

    void SpawnObjects()
    {
        if (foods.Length > 0)
        {
            // Set random spawn location and random object index
            //spawnLocation = new Vector3(Random.Range(-2, 2), Random.Range(17, 19), Random.Range(-2, 2));
            Instantiate(foods[GetRandomFood()], spawnLocation, foods[GetRandomFood()].transform.rotation);
        }                
    }

    int GetRandomFood()
    {
        return Random.Range(0, foods.Length);
    }

    IEnumerator FoodWave()
    {
        for (int i = 0; i < totalFoodsToSpawn; i++)
        {
            respawnTime = Random.Range(0.2f, 1.5f);
            yield return new WaitForSeconds(respawnTime);
            SpawnObjects();
        }        
    }

    private void OnDrawGizmos()
    {
        if (drawSpawnArea)
        {
            Gizmos.color = new Color(1f, 0, 0, 0.2f);
            Gizmos.DrawCube(spawnLocation, new Vector3(1, 1, 1));
        }
        
    }

}
