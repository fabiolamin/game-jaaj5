using UnityEngine;

public class BreakableGround : MonoBehaviour, ITarget
{
    private LootGenerator lootGenerator;

    [SerializeField] private GameObject breakableGroundParticles;
    [SerializeField] private AudioClip breakableGroundClip;

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
            Destroy();
        }
    }

    public void Destroy()
    {
        AudioSource.PlayClipAtPoint(breakableGroundClip, transform.position, 1f);
        lootGenerator.Generate();
        Instantiate(breakableGroundParticles, transform.position, Quaternion.identity, transform.parent);
        gameObject.SetActive(false);
    }
}
