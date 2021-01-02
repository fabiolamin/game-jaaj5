using UnityEngine;
using System.Collections;

public class BreakableGround : MonoBehaviour
{
    [SerializeField] private float delayToBreak = 0.1f;
    [SerializeField] private GameObject breakableGroundParticles;

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
        PlayerManager.Instance.PlayerAttack.IsReadyToAttackByAir = false;
        Instantiate(breakableGroundParticles, transform.position, Quaternion.identity, transform.parent);
        gameObject.SetActive(false);
    }
}
