using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool airAttackInput;

    [SerializeField] private Collider2D footCollider;
    [SerializeField] private float defaultAttackRange = 5f;
    [SerializeField] private int defaultAttackDamage = 5;

    public bool IsReadyToAttackByAir { get; set; } = false;

    private void Update()
    {
        SetAirAttack();
        SetDefaultAttack();

        Debug.DrawRay(transform.position, transform.forward * defaultAttackRange, Color.red);
    }

    private void SetAirAttack()
    {
        airAttackInput = Input.GetKey(KeyCode.DownArrow) &&
        !PlayerManager.Instance.PlayerMovement.IsOnTheGround();

        PlayerManager.Instance.PlayerAnimator.SetBool("IsAttackingByAir", airAttackInput);
    }

    private void SetDefaultAttack()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            PlayerManager.Instance.PlayerAnimator.SetTrigger("DefaultAttack");

            RaycastHit2D target = Physics2D.Raycast(transform.position, transform.forward, defaultAttackRange, LayerMask.GetMask("Enemy"));

            if(target)
            {
                target.collider.GetComponent<Enemy>().Hit(defaultAttackDamage);
            }
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

    public bool CanAttackEnemyByAir()
    {
        return CanAttackByAir() &&
        Physics2D.IsTouchingLayers(footCollider, LayerMask.GetMask("Enemy"));
    }
}
