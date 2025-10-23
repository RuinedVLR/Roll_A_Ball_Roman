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
            Vector3 spawnPosition1 = new Vector3(transform.position.x + 4, transform.position.y, transform.position.z);
            Vector3 spawnPosition2 = new Vector3(transform.position.x + 4, transform.position.y, transform.position.z + 4);
            Vector3 spawnPosition3 = new Vector3(transform.position.x, transform.position.y, transform.position.z + 4);
            Vector3 spawnPosition4 = new Vector3(transform.position.x - 4, transform.position.y, transform.position.z + 4);
            Vector3 spawnPosition5 = new Vector3(transform.position.x - 4, transform.position.y, transform.position.z);
            Vector3 spawnPosition6 = new Vector3(transform.position.x - 4, transform.position.y, transform.position.z - 4);
            Vector3 spawnPosition7 = new Vector3(transform.position.x, transform.position.y, transform.position.z - 4);
            Vector3 spawnPosition8 = new Vector3(transform.position.x + 4, transform.position.y, transform.position.z - 4);
            Quaternion bulletRotation1 = Quaternion.identity;
            Quaternion bulletRotation2 = Quaternion.identity;
            Quaternion bulletRotation3 = Quaternion.identity;
            Quaternion bulletRotation4 = Quaternion.identity;
            Quaternion bulletRotation5 = Quaternion.identity;
            Quaternion bulletRotation6 = Quaternion.identity;
            Quaternion bulletRotation7 = Quaternion.identity;
            Quaternion bulletRotation8 = Quaternion.identity;

            GameObject newBullet1 = Instantiate(bullet, spawnPosition1, bulletRotation1);
            GameObject newBullet2 = Instantiate(bullet, spawnPosition2, bulletRotation2);
            GameObject newBullet3 = Instantiate(bullet, spawnPosition3, bulletRotation3);
            GameObject newBullet4 = Instantiate(bullet, spawnPosition4, bulletRotation4);
            GameObject newBullet5 = Instantiate(bullet, spawnPosition5, bulletRotation5);
            GameObject newBullet6 = Instantiate(bullet, spawnPosition6, bulletRotation6);
            GameObject newBullet7 = Instantiate(bullet, spawnPosition7, bulletRotation7);
            GameObject newBullet8 = Instantiate(bullet, spawnPosition8, bulletRotation8);

            newBullet1.transform.parent = null;

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.forward * bulletSpeed;
            }

            timer = 0f;

        }
    }
}
