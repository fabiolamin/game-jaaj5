using UnityEngine;
using UnityEngine.UI;

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
        UpdateTimer(-(Time.deltaTime * decrementSpeed));
    }

    public void UpdateTimer(float amount)
    {
        currentTimer = Mathf.Clamp(currentTimer + amount, 0, timer);
        playerTimerBar.fillAmount = currentTimer / timer;
        CheckTimer();
    }

    private void CheckTimer()
    {
        if (currentTimer <= 0)
        {
            PlayerManager.Instance.PlayerHealth.GetDamage(1);
            currentTimer = timer;
        }
    }
}
