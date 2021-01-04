using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool airAttackInput;

    public bool IsReadyToAttackByAir { get; set; } = false;

    private void Update()
    {
        SetAirAttackInput();
        PlayerManager.Instance.PlayerAnimator.SetBool("IsAttackingByAir", airAttackInput);
    }

    private void SetAirAttackInput()
    {
        airAttackInput = Input.GetKey(KeyCode.DownArrow) &&
        !PlayerManager.Instance.PlayerMovement.IsOnTheGround();
    }

    public bool CanAttackByAir()
    {
        return IsReadyToAttackByAir &&
        airAttackInput &&
        !PlayerManager.Instance.PlayerMovement.IsTouchingRoof();
    }
}
