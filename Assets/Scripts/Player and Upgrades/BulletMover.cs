using System.Xml.Serialization;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    private Vector3 moveDirection;
    private float speed;
    private float lifetime;
    private float timer;
    public float damage = 10f;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyScript>(out EnemyScript enemyComponent))
        {
            Debug.Log("Enemy hit");
            enemyComponent.Die();
        }

        if(!collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
