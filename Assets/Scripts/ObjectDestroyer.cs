using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    [SerializeField] private float _leftBoundary = -15f;
    [SerializeField] private float _rightBoundary = 15f;

    private void Update()
    {
        if (transform.position.x < _leftBoundary || transform.position.x > _rightBoundary)
        {
            Destroy(gameObject);
        }
    }
}