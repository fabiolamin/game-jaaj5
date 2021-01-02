using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private Text scoreText;

    private void Awake()
    {
        scoreText.text = score.ToString();
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}
