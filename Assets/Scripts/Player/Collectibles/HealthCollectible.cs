using System;

public class HealthCollectible : Collectible
{
    public override void AddToPlayer()
    {
        PlayerManager.Instance.PlayerHealth.UpdateHealth(Convert.ToInt32(amount));
        gameObject.SetActive(false);
    }
}
