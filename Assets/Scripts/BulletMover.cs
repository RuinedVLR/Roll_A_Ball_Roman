using UnityEngine;

public class BulletMover : MonoBehaviour
{
    private Vector3 moveDirection;
    private float speed;
    private float lifetime;
    private float timer;

    public void Initialize(Vector3 direction, float bulletSpeed, float duration)
    {
        moveDirection = direction;
        speed = bulletSpeed;
        lifetime = duration;
        timer = 0f;
    }

    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
        timer += Time.deltaTime;

        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }

}
