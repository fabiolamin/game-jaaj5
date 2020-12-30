public class HealthCollectible : Collectible
{
    protected override void AddToPlayer()
    {
        //Add health to player
        gameObject.SetActive(false);
    }
}
