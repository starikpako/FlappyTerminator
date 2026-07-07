using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Terminator _terminator;
    [SerializeField] private EnemyGenerator _enemyGenerator;
    [SerializeField] private TMP_Text _scoreText;

    private int _score;

    private void OnEnable()
    {
        if (_terminator != null)
            _terminator.Died += OnPlayerDied;

        if (_enemyGenerator != null)
            _enemyGenerator.EnemySpawned += OnEnemySpawned;
    }

    private void OnDisable()
    {
        if (_terminator != null)
            _terminator.Died -= OnPlayerDied;

        if (_enemyGenerator != null)
            _enemyGenerator.EnemySpawned -= OnEnemySpawned;
    }

    private void Start()
    {
        UpdateScoreView();
    }

    private void OnEnemySpawned(Enemy enemy)
    {
        enemy.Died += OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;

        _score++;
        UpdateScoreView();

        _enemyGenerator.DestroyEnemy(enemy);
    }

    private void OnPlayerDied()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void UpdateScoreView()
    {
        if (_scoreText != null)
        {
            _scoreText.text = $"SCORE: {_score}";
        }
    }
}