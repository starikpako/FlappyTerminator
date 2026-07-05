using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    private float _width;                      
    private void Start()
    {
        if (TryGetComponent(out SpriteRenderer spriteRenderer))
        {
            _width = spriteRenderer.bounds.size.x;
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);

        if (transform.position.x <= -_width)
        {
            transform.position += new Vector3(_width * 2f, 0, 0);
        }
    }
}