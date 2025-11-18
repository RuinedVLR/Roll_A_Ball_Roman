using UnityEngine;

public class Collector : MonoBehaviour
{

    public static bool isCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUps"))
        {
            Debug.Log("PickUp Collected");
            Destroy(other.gameObject);
            isCollected = true;
        }
    }
}
