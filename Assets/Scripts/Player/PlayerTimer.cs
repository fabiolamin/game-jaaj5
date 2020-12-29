using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerTimer : MonoBehaviour
{
    private float currentTimer;
    [SerializeField] private float timer = 5f;
    [SerializeField] private float decrementSpeed = 2f;
    [SerializeField] private float amountToIncrement = 5f;
    [SerializeField] private Image playerTimerUI;

    private void Awake()
    {
        currentTimer = timer;
    }

    private void Update()
    {
        UpdateTimer();
        CheckTimer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Finish"))
        {
            FillTimer();
            Destroy(collision.gameObject);
        }
    }

    private void UpdateTimer()
    {
        currentTimer -= Time.deltaTime * decrementSpeed;
        playerTimerUI.fillAmount = currentTimer / timer;
    }

    private void CheckTimer()
    {
        if (currentTimer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void FillTimer()
    {
        currentTimer = Mathf.Clamp(currentTimer + amountToIncrement, 0, timer);
    }
}
