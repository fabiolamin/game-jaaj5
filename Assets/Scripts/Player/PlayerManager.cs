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

    private void Awake()
    {
        instance = this;
        PlayerMovement = GetComponent<PlayerMovement>();
        PlayerTimer = GetComponent<PlayerTimer>();
        PlayerHealth = GetComponent<PlayerHealth>();
    }
}
