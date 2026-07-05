using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint; 
    [SerializeField] private float _shootDelay = 2f;

    private void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_shootDelay);

            Shoot();
        }
    }

    private void Shoot()
    {
        if (_bulletPrefab != null)
        {
            Vector3 spawnPos = _shootPoint != null ? _shootPoint.position : transform.position;

            GameObject bulletObj = Instantiate(_bulletPrefab, spawnPos, Quaternion.identity);

            if (bulletObj.TryGetComponent(out Bullet bulletScript))
            {
                bulletScript.Initialize(Vector2.left, false);
            }
        }
    }

    public void Die()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddPoint();
        }
        Destroy(gameObject);
    }
}