using UnityEngine;
using System.Collections.Generic;


public class SpawnRandomizer : MonoBehaviour
{
    public int countExists;     //how many enemies exist
    public GameObject objectToSpawn;    //enemy prefab
    public Transform parentTransform;   //parent object

    [SerializeField] private GameObject[] chars;
    private Transform playerTransform;   //player object

    private Vector3 spawnRangeMin = new Vector3(-145f, 0.5f, -70f);
    private Vector3 spawnRangeMax = new Vector3(145f, 0.5f, 70f);

    public float spawnDelay = 4f;
    public float scaleTimer;

    private float timer = 0f;
    private int maxObjects = 200;
    public List<GameObject> spawnedObj = new List<GameObject>();



    private void Awake()
    {
        playerTransform = chars[SaveManager.instance.currentChar].transform;
    }

    // Update is called once per frame
    void Update()
    {
        countExists = spawnedObj.Count;
        spawnedObj.RemoveAll(item => item == null);
        scaleTimer += Time.deltaTime;        
        
        if (countExists < maxObjects)       //do not spawn more than 200
        {
            if(scaleTimer >= 7.5f)      //every 10 seconds decrease spawn delay
            {
                scaleTimer = 0f;
                spawnDelay -= 0.25f;
            }
            

            if (spawnDelay <= 0.1f)
            {
                spawnDelay = 0.1f;
            }
            
            timer += Time.deltaTime;

            if (timer >= spawnDelay)            //Spawn an enemy randomly in a defined range with a delay
            {
                Vector3 spawnPosition;
                int attempts = 0;
                do
                {
                    spawnPosition = new Vector3(            // Generate a random number from -70 to 70 (represents coordinates)
                    UnityEngine.Random.Range(spawnRangeMin.x, spawnRangeMax.x),
                    UnityEngine.Random.Range(spawnRangeMin.y, spawnRangeMax.y),
                    UnityEngine.Random.Range(spawnRangeMin.z, spawnRangeMax.z)
                    );

                    attempts++;
                }
                while((Mathf.Abs(spawnPosition.x - playerTransform.position.x) < 15f &&
                       Mathf.Abs(spawnPosition.z - playerTransform.position.z) < 15f) && attempts < 10); // Ensure spawn is at least 15 units away from player


                GameObject newObj = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity, parentTransform);
                spawnedObj.Add(newObj);
                
                timer = 0f;
            }
        }
    }
}
