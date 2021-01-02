public class TimerCollectible : Collectible
{
    protected override void AddToPlayer()
    {
        PlayerManager.Instance.PlayerTimer.UpdateTimer(amount);
        gameObject.SetActive(false);
    }
}
