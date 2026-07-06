using System;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _spawnDelay = 2f;

    public event Action<Enemy> EnemySpawned;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnDelay)
        {
            _timer = 0f;
            Spawn();
        }
    }

    public void DestroyEnemy(Enemy enemy)
    {
        if (enemy != null)
        {
            Destroy(enemy.gameObject);
        }
    }

    private void Spawn()
    {
        if (_enemyPrefab != null)
        {
            Vector3 spawnPosition = new Vector3(10f, UnityEngine.Random.Range(-4f, 4f), 0f);
            Enemy spawnedEnemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);


            EnemySpawned?.Invoke(spawnedEnemy);
        }
    }
}