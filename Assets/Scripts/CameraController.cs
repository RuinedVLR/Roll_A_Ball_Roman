using Unity.Hierarchy;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float followDistance = 5f;
    public Vector3 offset = new Vector3(0, 2, 0);

    public float sensetivity = 100f;
    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensetivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensetivity;

        rotationY += mouseX;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, 60f, 60f);

        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0f);

        Vector3 targetPosition = player.position + offset - rotation * Vector3.forward * followDistance;

        transform.position = targetPosition;
        transform.rotation = rotation;
    }


    //void LateUpdate()
    //{
    //    transform.position = player.transform.position + offset;
    //}


}
