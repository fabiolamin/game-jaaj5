using System;

public class HealthCollectible : Collectible
{
    protected override void AddToPlayer()
    {
        PlayerManager.Instance.PlayerHealth.UpdateHealth(Convert.ToInt32(amount));
        gameObject.SetActive(false);
    }
}
