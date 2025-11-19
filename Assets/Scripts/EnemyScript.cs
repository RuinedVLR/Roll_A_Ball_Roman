using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private Transform player;
    public Transform enemyPosition;
    public Transform enemyParent;
    public GameObject enemy;
    public GameObject pickUpToSpawn;
    private NavMeshAgent navMeshAgent;
    
    void Start()
    {
        player = SpawnChosenChar.player.transform;

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    public void Die()
    {
        Vector3 spawnPosition = new Vector3(enemyPosition.transform.position.x, enemyPosition.transform.position.y, enemyPosition.transform.position.z);
        Destroy(gameObject);
        GameObject newObj = Instantiate(pickUpToSpawn, spawnPosition, Quaternion.identity, enemyParent);
    }
}
