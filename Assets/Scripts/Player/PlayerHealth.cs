using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private int currentLives;
    [SerializeField] private int lives;
    [SerializeField] private Text playerLivesText;
    [SerializeField] private AudioClip damageClip;

    private void Awake()
    {
        currentLives = lives;
    }

    public void GetDamage()
    {
        PlayerManager.Instance.AudioSource.PlayOneShot(damageClip);
        PlayerManager.Instance.PlayerAnimator.SetTrigger("GetDamage");
        currentLives = Mathf.Clamp(currentLives - 1, 0, lives);
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
