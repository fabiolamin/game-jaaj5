using UnityEngine;

public class TimerCollectible : Collectible
{
    protected override void AddToPlayer()
    {
        PlayerManager.Instance.PlayerTimer.AddTimer(amount);
        gameObject.SetActive(false);
    }
}
