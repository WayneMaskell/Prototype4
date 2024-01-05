using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lopps : MonoBehaviour
{
    public bool condition;
    public int maxHealth;
    public GameObject[] cubePrefabs;


    // Start is called before the first frame update
   // void Start()
    //{
        //for (int x = 0;  x < 100; x++)
           // { for (int z = 0; z < 100; z++)
              //  if (z % 2 == 0 && x % 2 == 0)
           // { Instantiate(cubePrefab[Random.Range(0,cubePrefab.Length)], new Vector3(x, 0, z), Quaternion.identity); }
        //}
        
  //  }

    // Update is called once per frame
   // void Update()
   // {
   // UseWhileLoop();

    // }


 void Start()
    {
        SpawnSquare();
        //for (int x = 0; x < 100; x++)
        //{
        //    for (int z = 0; z < 100; z++)
        //    {
        //        SpawnCubesAtRandom(x, z);

        //    }
        }

   // }

    private void SpawnCubes(int x, int z)
    {
        if (z % 2 == 0 && x % 2 == 0)
        {
            Instantiate(cubePrefabs[0], new Vector3(x, 0, z), Quaternion.identity);
        }
        else if (x % 2 != 0 && z % 2 != 0)
        {
            Instantiate(cubePrefabs[1], new Vector3(x, 1, z), Quaternion.identity);
        }
        else
        {
            Instantiate(cubePrefabs[2], new Vector3(x, 2, z), Quaternion.identity);
        }
    }

    private void SpawnCubesAtRandom(int x, int z)
    {
        if (Random.value > 0.7)
        {
            Instantiate(cubePrefabs[Random.Range(0, cubePrefabs.Length)], new Vector3(x, 2, z), Quaternion.identity);

        }
    }

    private void SpawnSquare() 
    {
        for (int x = 0; x<100; x++) { for (int z = 0; z < 100; z++) 
            {
                if (x == 0 && z < 100) { Instantiate(cubePrefabs[0], new Vector3(x, 0, z), Quaternion.identity); }
                if (x == 99 && z < 100) { Instantiate(cubePrefabs[0], new Vector3(x, 0, z), Quaternion.identity); }
                if (z == 0 && x < 100) { Instantiate(cubePrefabs[0], new Vector3(x, 0, z), Quaternion.identity); }
                if(z == 99 && x < 100) { Instantiate(cubePrefabs[0], new Vector3(x, 0, z), Quaternion.identity); }
                if((z>44) && (z<56) && (x>44) && (x < 56)){ Instantiate(cubePrefabs[1], new Vector3(x, 0, z), Quaternion.identity); }
                if ((z > 45) && (z < 55) && (x > 45) && (x < 55)) { Instantiate(cubePrefabs[1], new Vector3(x, 1, z), Quaternion.identity); }
                if ((z > 46) && (z < 54) && (x > 46) && (x < 54)) { Instantiate(cubePrefabs[1], new Vector3(x, 2, z), Quaternion.identity); }
                if ((z > 47) && (z < 53) && (x > 47) && (x < 53)) { Instantiate(cubePrefabs[1], new Vector3(x, 3, z), Quaternion.identity); }
                if ((z > 48) && (z < 52) && (x > 48) && (x < 52)) { Instantiate(cubePrefabs[1], new Vector3(x, 4, z), Quaternion.identity); }
                if ((z > 49) && (z < 51) && (x > 49) && (x < 51)) { Instantiate(cubePrefabs[1], new Vector3(x, 5, z), Quaternion.identity); }
                if ((z > 50) && (z < 50) && (x > 50) && (x < 50)) { Instantiate(cubePrefabs[1], new Vector3(x, 6, z), Quaternion.identity); }
            } }
        
        

    }
    private void SpawnPyramid() 
    {
        
       




    }


    // Update is called once per frame
    void Update()
    {

    }

    //private void UseWhileLoop()
    //{
    //    while (maxHealth < 5)
    //    {
    //        Debug.Log("While Loop is ongoing");
    //        maxHealth++;
    //    }
    //}

    //private void UseDoWhileLoop()
    //{
    //    do
    //    {
    //        Debug.Log("Doing Something Before While Loop Starts");
    //        maxHealth++;
    //    } while (maxHealth < 5);
    //}

    //private void RegenPlayerHealth()
    //{
    //    while (playerHealth < maxHealth)
    //    {

    //        playerHealth++;
    //    }
    //}
}
