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
    }

    private void UpdateTimer()
    {
        currentTimer -= Time.deltaTime * decrementSpeed;
        playerTimerBar.fillAmount = currentTimer / timer;
        CheckTimer();
    }

    private void CheckTimer()
    {
        if (currentTimer <= 0)
        {
            PlayerManager.Instance.PlayerHealth.UpdateHealth(-1);
            currentTimer = timer;
        }
    }

    public void AddTimer(float amount)
    {
        currentTimer = Mathf.Clamp(currentTimer + amount, 0, timer);
    }
}
