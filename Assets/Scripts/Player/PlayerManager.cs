using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    public PlayerMovement PlayerMovement { get; private set; }
    public PlayerTimer PlayerTimer { get; private set; }

    private void Awake()
    {
        CheckInstance();
        PlayerMovement = GetComponent<PlayerMovement>();
        PlayerTimer = GetComponent<PlayerTimer>();
    }

    private void CheckInstance()
    {
        Instance = this;

        if (Instance == null)
        {
            Debug.LogError("PlayerManager is NULL.");
        }
    }
}
