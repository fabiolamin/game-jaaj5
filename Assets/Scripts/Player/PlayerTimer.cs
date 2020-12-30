using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerTimer : MonoBehaviour
{
    private float currentTimer;
    [SerializeField] private float timer = 5f;
    [SerializeField] private float decrementSpeed = 2f;
    [SerializeField] private Image playerTimerBar;

    private void Awake()
    {
        currentTimer = timer;
    }

    private void Update()
    {
        UpdateTimer();
        CheckTimer();
    }

    private void UpdateTimer()
    {
        currentTimer -= Time.deltaTime * decrementSpeed;
        playerTimerBar.fillAmount = currentTimer / timer;
    }

    private void CheckTimer()
    {
        if (currentTimer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddTimer(float amount)
    {
        currentTimer = Mathf.Clamp(currentTimer + amount, 0, timer);
    }
}
