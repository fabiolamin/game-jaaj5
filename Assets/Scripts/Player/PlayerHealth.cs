using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private int currentLives;
    [SerializeField] private int lives;
    [SerializeField] private Text playerLivesText;

    private void Awake()
    {
        currentLives = lives;
    }

    public void GetDamage(int amount)
    {
        currentLives = Mathf.Clamp(currentLives - amount, 0, lives);
        playerLivesText.text = currentLives.ToString();
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (currentLives <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
