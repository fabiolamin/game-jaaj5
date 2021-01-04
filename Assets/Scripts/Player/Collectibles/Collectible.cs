using System.Collections;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private Rigidbody2D collectibleRb;
    private Collider2D collectibleCollider;
    private bool hasBeenCaught = false;

    [Header("Amount")]
    [SerializeField] protected int timerAmount = 3;
    [SerializeField] protected int pointsAmount = 3;

    [Header("Spawning")]
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private float spawnForce = 5f;
    [SerializeField] private float delayToBeCaught = 3f;
    [SerializeField] private Color[] colors;

    public bool IsReadyToFollowPlayer { get; set; } = false;

    private void Awake()
    {
        collectibleRb = GetComponent<Rigidbody2D>();
        collectibleCollider = GetComponent<Collider2D>();
        collectibleCollider.enabled = false;
        SetRandomColor();
        SetRandomDirection();
        StartCoroutine(AwaitToBeCaught());
    }

    private void Update()
    {
        if (IsReadyToFollowPlayer)
        {
            collectibleRb.velocity = Vector2.zero;
            FollowPlayer();
        }
    }

    private void SetRandomColor()
    {
        GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];
    }

    private void SetRandomDirection()
    {
        collectibleRb.velocity = Random.insideUnitCircle.normalized * spawnForce;
    }

    private IEnumerator AwaitToBeCaught()
    {
        yield return new WaitForSeconds(delayToBeCaught);
        collectibleCollider.enabled = true;
    }

    private void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, PlayerManager.Instance.transform.position, followSpeed * Time.deltaTime);
    }

    public void AddToPlayer()
    {
        if (!hasBeenCaught)
        {
            hasBeenCaught = true;
            PlayerManager.Instance.PlayerTimer.UpdateTimer(timerAmount);
            PlayerManager.Instance.PlayerScore.AddScore(pointsAmount);
            gameObject.SetActive(false);
        }
    }
}
