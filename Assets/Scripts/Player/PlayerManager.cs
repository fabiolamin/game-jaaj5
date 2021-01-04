using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("PlayerManager is NULL.");
            }

            return instance;
        }
    }
    public PlayerMovement PlayerMovement { get; private set; }
    public PlayerTimer PlayerTimer { get; private set; }
    public PlayerHealth PlayerHealth { get; private set; }
    public PlayerScore PlayerScore { get; private set; }
    public PlayerAttack PlayerAttack { get; private set; }
    public Animator PlayerAnimator { get; private set; }

    private void Awake()
    {
        instance = this;
        PlayerMovement = GetComponent<PlayerMovement>();
        PlayerTimer = GetComponent<PlayerTimer>();
        PlayerHealth = GetComponent<PlayerHealth>();
        PlayerScore = GetComponent<PlayerScore>();
        PlayerAttack = GetComponent<PlayerAttack>();
        PlayerAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        CheckForCollectible(other);
    }

    private void CheckForCollectible(Collision2D other)
    {
        Collectible collectible = other.gameObject.GetComponent<Collectible>();
        if (collectible && !collectible.HasBeenCaught)
        {
            CatchCollectible(collectible);
        }
    }

    private void CatchCollectible(Collectible collectible)
    {
        collectible.HasBeenCaught = true;
        PlayerTimer.UpdateTimer(collectible.TimerAmount);
        PlayerScore.AddScore(collectible.PointsAmount);
        collectible.gameObject.SetActive(false);
    }
}
