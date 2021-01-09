using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] private ParticleSystem collectionRewardParticles;
    [SerializeField] private AudioClip collectibleClip;
    private void OnCollisionEnter2D(Collision2D other)
    {
        CheckForCollectible(other);
    }

    private void CheckForCollectible(Collision2D other)
    {
        Collectible collectible = other.gameObject.GetComponent<Collectible>();
        if (collectible && !collectible.HasBeenCaught)
        {
            CatchCollectible(collectible);
        }
    }

    private void CatchCollectible(Collectible collectible)
    {
        collectible.HasBeenCaught = true;
        PlayerManager.Instance.AudioSource.PlayOneShot(collectibleClip);
        AddCollectiblesToPlayer(collectible);
        PlayParticles();
        collectible.gameObject.SetActive(false);
    }

    private void AddCollectiblesToPlayer(Collectible collectible)
    {
        PlayerManager.Instance.PlayerTimer.UpdateTimer(collectible.TimerAmount);
        PlayerManager.Instance.PlayerScore.AddScore(collectible.PointsAmount);
    }

    private void PlayParticles()
    {
        if (collectionRewardParticles.isStopped)
        {
            collectionRewardParticles.Play();
        }
    }
}
