using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemys;
    public float delay = 2f;
    public float interval = 2f;
    public float speed = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", delay, interval);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy() 
    {
         int randoenemy = Random.Range(0, enemys.Length);
        Vector3 position = new Vector3(Random.Range(7.0f,- 7.0f), 1,(Random.Range(7.0f, -7.0f)));
        Instantiate(enemys[randoenemy] , position, Quaternion.identity);
        

    }
}
