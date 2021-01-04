using UnityEngine;
using System.Collections;

public class BreakableGround : MonoBehaviour
{
    [SerializeField] private float delayToBreak = 0.1f;
    [SerializeField] private GameObject breakableGroundParticles;

    [Header("Collectibles Spawning")]
    [SerializeField] private bool canSpawnCollectibles = true;
    [SerializeField] private Collectible collectible;
    [SerializeField] private int amountToSpawn = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckIfPlayerCanBreak();
    }

    private void CheckIfPlayerCanBreak()
    {
        if (PlayerManager.Instance.PlayerAttack.CanAttackByAir())
        {
            StartCoroutine(AwaitToBreak());
        }
        else
        {
            PlayerManager.Instance.PlayerAttack.IsReadyToAttackByAir = false;
        }
    }

    private IEnumerator AwaitToBreak()
    {
        yield return new WaitForSeconds(delayToBreak);
        Break();
    }

    private void Break()
    {
        SpawnCollectibles();
        PlayerManager.Instance.PlayerAttack.IsReadyToAttackByAir = false;
        Instantiate(breakableGroundParticles, transform.position, Quaternion.identity, transform.parent);
        gameObject.SetActive(false);
    }

    private void SpawnCollectibles()
    {
        if (canSpawnCollectibles)
        {
            for (int x = 0; x < amountToSpawn; x++)
            {
                Instantiate(collectible, transform.position, Quaternion.identity);
            }
        }
    }
}
