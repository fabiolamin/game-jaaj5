using UnityEngine;

public class TimerCollectible : Collectible
{
    protected override void AddToPlayer()
    {
        Debug.Log("Add timer!");
        Destroy(gameObject);
    }
}
