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

    private void Awake()
    {
        instance = this;
        PlayerMovement = GetComponent<PlayerMovement>();
        PlayerTimer = GetComponent<PlayerTimer>();
        PlayerHealth = GetComponent<PlayerHealth>();
        PlayerScore = GetComponent<PlayerScore>();
        PlayerAttack = GetComponent<PlayerAttack>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        CheckForCollectibles(other);
    }

    private static void CheckForCollectibles(Collision2D other)
    {
        Collectible collectible = other.gameObject.GetComponent<Collectible>();
        if (collectible)
        {
            collectible.AddToPlayer();
        }
    }
}
