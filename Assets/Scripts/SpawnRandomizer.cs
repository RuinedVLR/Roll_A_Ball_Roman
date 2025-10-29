using UnityEngine;
using System.Collections.Generic;


public class SpawnRandomizer : MonoBehaviour
{
    public int countExists;     //how many pickups exist
    public GameObject objectToSpawn;    //pickup prefab
    public Transform parentTransform;   //parent object
    private Vector3 spawnRangeMin = new Vector3(-70f, 0.5f, -70f);
    private Vector3 spawnRangeMax = new Vector3(70f, 0.5f, 70f);

    public float spawnDelay = 2f;
    public float scaleTimer;
    public float timer = 0f;
    public int maxObjects = 100;
    public List<GameObject> spawnedObj = new List<GameObject>();   
    


    // Update is called once per frame
    void Update()
    {

        countExists = spawnedObj.Count;

        spawnedObj.RemoveAll(item => item == null);

        scaleTimer += Time.deltaTime;        
        
        if (countExists < maxObjects)       //do not spawn more than 40
        {
            spawnDelay -= 0.00001f * scaleTimer;

            if (spawnDelay <= 0.1f)
            {
                spawnDelay = 0.1f;
            }
            
            timer += Time.deltaTime;

            if (timer >= spawnDelay)            //Spawn a pickup randomly in a defined range with a delay
            {
                Vector3 spawnPosition = new Vector3(            // Generate a random number from -70 to 70 (represents coordinates)
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
