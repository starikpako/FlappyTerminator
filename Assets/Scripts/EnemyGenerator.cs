using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _delay = 2f;    
    [SerializeField] private float _minSpawnY = -3f;  
    [SerializeField] private float _maxSpawnY = 3f; 

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(_delay);
        }
    }

    private void Spawn()
    {
        float randomY = Random.Range(_minSpawnY, _maxSpawnY);

        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);

        Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
    }
}