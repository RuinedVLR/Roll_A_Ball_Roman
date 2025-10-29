using Unity.VisualScripting;
using UnityEngine;

public class PickUp1 : MonoBehaviour
{
    Rigidbody rb;

    bool hasTarget;
    Vector3 targetPosition;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (hasTarget)
        {
            Vector3 targetDirection = (targetPosition - transform.position).normalized;
            rb.linearVelocity = new Vector3(targetDirection.x, targetDirection.y, targetDirection.z) * (PlayerControls.speed + 20);
        }
    }

    public void SetTarget(Vector3 position)
    {
        targetPosition = position;
        hasTarget = true;
    }
}
