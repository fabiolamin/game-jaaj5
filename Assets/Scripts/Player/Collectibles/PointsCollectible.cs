public class PointsCollectible : Collectible
{
    public override void AddToPlayer()
    {
        PlayerManager.Instance.PlayerScore.AddScore(amount);
        gameObject.SetActive(false);
    }
}
