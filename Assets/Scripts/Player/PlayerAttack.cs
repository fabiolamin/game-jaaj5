using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool airAttackInput;

    [SerializeField] private float defaultAttackRange = 5f;
    [SerializeField] private int defaultAttackDamage = 5;

    public bool IsReadyToAttackByAir { get; set; } = false;

    private void Update()
    {
        SetAirAttack();
        CheckDefaultAttack();
    }

    private void SetAirAttack()
    {
        airAttackInput = Input.GetKey(KeyCode.DownArrow) &&
        !PlayerManager.Instance.PlayerMovement.IsOnTheGround();

        PlayerManager.Instance.PlayerAnimator.SetBool("IsAttackingByAir", airAttackInput);
    }

    private void CheckDefaultAttack()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SetDefaultAttack();
        }
    }

    private void SetDefaultAttack()
    {
        PlayerManager.Instance.PlayerAnimator.SetTrigger("DefaultAttack");

        Vector2 forward = PlayerManager.Instance.PlayerMovement.ForwardDirection;
        RaycastHit2D target = Physics2D.Raycast(transform.position, forward, defaultAttackRange, LayerMask.GetMask("Enemy"));

        if (target)
        {
            Enemy enemy = target.collider.transform.root.GetComponent<Enemy>();
            enemy.Hit(defaultAttackDamage);
        }
    }

    public bool CanAttackByAir()
    {
        return IsReadyToAttackByAir &&
        airAttackInput &&
        !PlayerManager.Instance.PlayerMovement.IsTouchingRoof();
    }

    public bool CanBreakTheGround()
    {
        return CanAttackByAir() &&
        PlayerManager.Instance.PlayerMovement.IsOnTheGround();
    }
}
