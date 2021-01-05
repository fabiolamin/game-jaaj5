using UnityEngine;
using System.Collections;

public class BreakableGround : MonoBehaviour
{
    private LootGenerator lootGenerator;

    [SerializeField] private float delayToBreak = 0.1f;
    [SerializeField] private GameObject breakableGroundParticles;

    private void Awake()
    {
        lootGenerator = GetComponent<LootGenerator>();    
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        CheckIfCanBeBroken();
    }

    private void CheckIfCanBeBroken()
    {
        if (PlayerManager.Instance.PlayerAttack.CanBreakTheGround())
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
        lootGenerator.Generate();
        PlayerManager.Instance.PlayerAttack.IsReadyToAttackByAir = false;
        Instantiate(breakableGroundParticles, transform.position, Quaternion.identity, transform.parent);
        gameObject.SetActive(false);
    }
}
