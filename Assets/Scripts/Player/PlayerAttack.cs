using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool airAttackInput;

    public bool IsReadyToAttackByAir { get; set; } = false;

    private void Update()
    {
        airAttackInput = Input.GetKey(KeyCode.DownArrow);
    }

    public bool CanAttackByAir()
    {
        return IsReadyToAttackByAir &&
        airAttackInput &&
        !PlayerManager.Instance.PlayerMovement.IsTouchingRoof();
    }
}
