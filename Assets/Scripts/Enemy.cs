using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootDelay = 0.5f;

    public event Action<Enemy> Died;

    private void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    public void Die()
    {
        Died?.Invoke(this);
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
            Bullet bulletInstance = Instantiate(_bulletPrefab, spawnPos, Quaternion.identity);

            bulletInstance.Initialize(Vector2.left, false);
        }
    }
}