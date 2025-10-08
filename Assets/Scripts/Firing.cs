using System.Threading;
using UnityEngine;

public class Firing : MonoBehaviour
{
    public GameObject bullet;
    public Transform parentObject;
    public float bulletSpeed = 10f;
    public float timer = 0f;
    public float delayTime = 1f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delayTime)
        {
            Vector3 spawnPosition = transform.position;
            Quaternion bulletRotation = Quaternion.identity;

            GameObject newBullet = Instantiate(bullet, spawnPosition, bulletRotation);

            newBullet.transform.parent = null;

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.forward * bulletSpeed;
            }

            timer = 0f;

        }
    }
}
