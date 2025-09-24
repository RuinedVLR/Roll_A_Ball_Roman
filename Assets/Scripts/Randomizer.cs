using UnityEngine;

public class Randomizer : MonoBehaviour
{
    public int countExists;
    public GameObject objectToSpawn;
    public Vector3 spawnRangeMin = new Vector3(-95f, 0.5f, -95f);
    public Vector3 spawnRangeMax = new Vector3(95f, 0.5f, 95f);

    public float spawnTimer;
    

    void Start()
    {
        countExists = 0;

        
        // Generate a random number from -95 to 95 (represents coordinates)
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer == 4)
        {
            spawnTimer = 0;

            Vector3 spawnPosition = new Vector3(
                Random.Range(spawnRangeMin.x, spawnRangeMax.x),
                Random.Range(spawnRangeMin.y, spawnRangeMax.y),
                Random.Range(spawnRangeMin.z, spawnRangeMax.z)
                );
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
        
        if (countExists > 20) //do not spawn more than 20
        {
            
            
            //Spawn a pickup randomly in a defined range with a delay of 3-5 seconds
        }

    }
}
