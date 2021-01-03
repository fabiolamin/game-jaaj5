using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Collectible collectible = other.gameObject.GetComponent<Collectible>();
        collectible.IsReadyToFollowPlayer = true;
    }
}
