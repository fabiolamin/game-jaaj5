using UnityEngine;

public class BreakableGround : MonoBehaviour
{
    private LootGenerator lootGenerator;

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
            Break();
        }
    }

    private void Break()
    {
        lootGenerator.Generate();
        Instantiate(breakableGroundParticles, transform.position, Quaternion.identity, transform.parent);
        gameObject.SetActive(false);
    }
}
