using UnityEngine;

public class CharAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 finalPosition;
    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, finalPosition, 0.05f);
    }

    private void OnDisable()
    {
        transform.position = startPosition;
    }
}
