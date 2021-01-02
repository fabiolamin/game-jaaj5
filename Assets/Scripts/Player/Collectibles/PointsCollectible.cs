public class PointsCollectible : Collectible
{
    protected override void AddToPlayer()
    {
        PlayerManager.Instance.PlayerScore.AddScore(amount);
        gameObject.SetActive(false);
    }
}
