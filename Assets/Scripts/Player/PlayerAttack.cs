using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool airAttackInput;

    [SerializeField] private float defaultAttackRange = 5f;
    [SerializeField] private int defaultAttackDamage = 5;
    [SerializeField] private AudioClip defaultAttackClip;

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
        PlayerManager.Instance.AudioSource.PlayOneShot(defaultAttackClip);
        PlayerManager.Instance.PlayerAnimator.SetTrigger("DefaultAttack");

        Vector2 forward = PlayerManager.Instance.PlayerMovement.ForwardDirection;
        RaycastHit2D other = Physics2D.Raycast(transform.position, forward, defaultAttackRange, LayerMask.GetMask("Target"));

        if (other)
        {
            ITarget target = other.collider.GetComponent<ITarget>();
            target.Destroy();
        }
    }

    public bool CanAttackByAir()
    {
        return airAttackInput &&
        !PlayerManager.Instance.PlayerMovement.IsTouchingRoof();
    }

    public bool CanBreakTheGround()
    {
        return CanAttackByAir() &&
        PlayerManager.Instance.PlayerMovement.IsOnTheGround();
    }
}
