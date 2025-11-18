using UnityEngine;

public class Magnet : MonoBehaviour
{
    public SphereCollider sphereCollider;

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.TryGetComponent<PickUp1>(out PickUp1 pickUp))
        {
            pickUp.SetTarget(transform.parent.position);
        }
    }

    private void Update()
    {
        sphereCollider.radius = 3 + LVLupMenu.magnetLvl;
    }
}
