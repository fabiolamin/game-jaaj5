public class TimerCollectible : Collectible
{
    public override void AddToPlayer()
    {
        PlayerManager.Instance.PlayerTimer.UpdateTimer(amount);
        gameObject.SetActive(false);
    }
}
