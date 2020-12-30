using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Collectible : MonoBehaviour
{
    protected bool hasBeenCollected = false;
    [SerializeField] protected int amount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasBeenCollected)
        {
            hasBeenCollected = true;
            AddToPlayer();
        }
    }

    protected abstract void AddToPlayer();
}
