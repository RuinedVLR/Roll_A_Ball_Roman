using System.Threading;
using UnityEngine;

public class Firing : MonoBehaviour
{
    public GameObject bullet;
    public Transform parentObject;
    public float bulletSpeed = 50f;
    public float timer = 0f;
    public static float delayTime = 2f;
    public float radius = 3f;

    public Transform bulletTransform;


    void Update()
    {
        bulletTransform.localScale = new Vector3(0.6f + (0.2f * LVLupMenu.firePowerLvl), 0.6f + (0.2f * LVLupMenu.firePowerLvl), 0.6f + (0.2f * LVLupMenu.firePowerLvl));

        delayTime = 2 - (0.15f * LVLupMenu.fireRateLvl);
        if (delayTime <= 0.2f)
        {
            delayTime = 0.2f;
        }
        
        timer += Time.deltaTime;

        if (timer >= delayTime)
        {
            Vector3 center = transform.position;

            Vector3[] offsets = new Vector3[]
            {
            new Vector3(1, 0, 0),
            new Vector3(1, 0, 1),
            new Vector3(0, 0, 1),
            new Vector3(-1, 0, 1),
            new Vector3(-1, 0, 0),
            new Vector3(-1, 0, -1),
            new Vector3(0, 0, -1),
            new Vector3(1, 0, -1)
            };

            foreach (Vector3 offset in offsets)
            {
                Vector3 spawnPos = center + offset.normalized * radius;
                Vector3 direction = (spawnPos - center).normalized;
                Quaternion rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 90, 0);

                GameObject newBullet = Instantiate(bullet, spawnPos, rotation);
                newBullet.transform.parent = null;

                BulletMover mover = newBullet.GetComponent<BulletMover>();
                if (mover != null)
                {
                    mover.Initialize(direction, bulletSpeed, 5f);
                }
            }

            timer = 0f;
        }
    }

}
