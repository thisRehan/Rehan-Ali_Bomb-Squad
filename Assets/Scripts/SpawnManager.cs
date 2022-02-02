using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject[] pickUp;
    private int enemyToSpawn = 2;
    private int noOfEnemy;
    private int waveToSpawn = 0;
    private int spawnStart = 2;
    private int spawnDelay = 5;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnPickUp", spawnStart, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        spawnEnemy();
    }
    void spawnEnemy()
    {
        noOfEnemy = FindObjectsOfType<Enemy>().Length;
        if(noOfEnemy == 0 && waveToSpawn <5)
        {
            for(int i=0; i<enemyToSpawn; i++)
                Instantiate(enemy, spawnPosition(), enemy.transform.rotation);
            waveToSpawn++;
        }
    }
    void spawnPickUp()
    {
        int index = Random.Range(0, pickUp.Length);
        Instantiate(pickUp[index], spawnPosition(), pickUp[index].transform.rotation);
    }
    Vector3 spawnPosition()
    {
        float xRange = 8;
        float zRange = 8;
        float xRandom = Random.Range(-xRange, xRange);
        float zRandom = Random.Range(-zRange, zRange);
        Vector3 spawnPosition = new Vector3(xRandom, 0, zRandom);
        return spawnPosition;
    }
}
