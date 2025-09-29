using NUnit.Framework;
using System;
using UnityEngine;
using System.Collections.Generic;


public class Randomizer : MonoBehaviour
{
    public int countExists;     //how many pickups exist
    public GameObject objectToSpawn;    //pickup prefab
    public Transform parentTransform;   //parent object
    public Vector3 spawnRangeMin = new Vector3(-95f, 0.5f, -95f);
    public Vector3 spawnRangeMax = new Vector3(95f, 0.5f, 95f);

    private float spawnDelay = 1f;
    public float timer = 0f;
    private int maxObjects = 40;
    public List<GameObject> spawnedObj = new List<GameObject>();   
    


    // Update is called once per frame
    void Update()
    {

        countExists = spawnedObj.Count;

        spawnedObj.RemoveAll(item => item == null);
        
        
        if (countExists < maxObjects)       //do not spawn more than 20
        {
            timer += Time.deltaTime;

            if (timer >= spawnDelay)            //Spawn a pickup randomly in a defined range with a delay
            {
                Vector3 spawnPosition = new Vector3(            // Generate a random number from -95 to 95 (represents coordinates)
                    UnityEngine.Random.Range(spawnRangeMin.x, spawnRangeMax.x),
                    UnityEngine.Random.Range(spawnRangeMin.y, spawnRangeMax.y),
                    UnityEngine.Random.Range(spawnRangeMin.z, spawnRangeMax.z)
                    );
                
                GameObject newObj = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity, parentTransform);

                spawnedObj.Add(newObj);
                
                timer = 0f;
            }
        }
    }
}
