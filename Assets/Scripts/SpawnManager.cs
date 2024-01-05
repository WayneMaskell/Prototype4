using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] enemys;
    public float delay = 2f;
    public float interval = 2f;
    public float speed = 100f;
    private float spawnRange = 9;
    public int enemyCount;
    public GameObject powerUpPrefab;
    public int waveCount;
    public GameObject bossPrefab;

    
    // Start is called before the first frame update
    void Start()
    {

        //InvokeRepeating("SpawnEnemy", delay, interval);
        SpawnEnemyWave(3);
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<FightingEnemy>().Length;
        if (enemyCount == 0) { SpawnEnemyWave(1); }
        if (enemyCount == 0 ) { Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation); }
        if (waveCount == 5) 
        { 
            Instantiate(bossPrefab, GenerateSpawnPosition(), bossPrefab.transform.rotation);
            SpawnEnemy();
            waveCount = 0;
        }

    }
    
    void SpawnEnemy() 
    {
         int randoenemy = Random.Range(0, enemys.Length);
        Vector3 position = new Vector3(Random.Range(7.0f,- 7.0f), 1,(Random.Range(7.0f, -7.0f)));
        Instantiate(enemys[randoenemy] , position, Quaternion.identity);
        

    }
    private void SpawnEnemyWave(int enemiesToSpawn) 
    {
        
        for (int i = 0; i< 3; i++) 
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
        waveCount++;
    }
    private Vector3 GenerateSpawnPosition() 
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosz = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosz);
        return randomPos;
    }
}
