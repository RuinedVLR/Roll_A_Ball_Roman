using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public Transform player;
    public Transform enemyPosition;
    public Transform enemyParent;
    public GameObject enemy;
    public GameObject pickUpToSpawn;
    private NavMeshAgent navMeshAgent;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 spawnPosition = new Vector3(enemyPosition.transform.position.x, enemyPosition.transform.position.y, enemyPosition.transform.position.z);
        
        if(player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }

        if (enemy == null)
        {
            GameObject newObj = Instantiate(pickUpToSpawn, spawnPosition, Quaternion.identity, enemyParent);
        }
    }
}
