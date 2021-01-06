using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    public int Score { get; private set; }

    private void Awake()
    {
        scoreText.text = Score.ToString();
    }

    public void AddScore(int amount)
    {
        Score += amount;
        scoreText.text = Score.ToString();
    }
}
