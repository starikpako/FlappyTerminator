using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    private Vector2 _direction;
    private bool _isPlayerBullet;

    public void Initialize(Vector2 direction, bool isPlayerBullet)
    {
        _direction = direction;
        _isPlayerBullet = isPlayerBullet;
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isPlayerBullet)
        {
            if (collision.TryGetComponent(out Enemy enemy))
            {
                enemy.Die();
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.TryGetComponent(out Terminator player))
            {
                player.Die();       
                Destroy(gameObject);
            }
        }
    }
}