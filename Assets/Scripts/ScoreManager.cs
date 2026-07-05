using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI _scoreText; 
    private int _score = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddPoint()
    {
        _score++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        _scoreText.text = "SCORE: " + _score;
    }
}