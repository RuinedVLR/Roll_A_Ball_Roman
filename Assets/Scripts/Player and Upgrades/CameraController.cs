using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;
    
    void Start()
    {
        player = SpawnChosenChar.player;
        offset = transform.position - player.transform.position;
    }

    
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
