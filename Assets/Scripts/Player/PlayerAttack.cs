using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool airAttackInput;

    public bool IsReadyToAttackByAir { get; set; } = false;

    private void Update()
    {
        SetAirAttack();
        SetDefaultAttack();
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
