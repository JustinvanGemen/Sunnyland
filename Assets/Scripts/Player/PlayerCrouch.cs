using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    //Mask to determine what is ground
    [SerializeField] private LayerMask _whatIsGround;
    //Position to check for ceilings (to check if character must be force crouched)
    [SerializeField] private Transform _ceilingCheck;
    //Collider disabled when crouching.
    [SerializeField] private Collider2D _crouchDisableCollider;
    //bool for checking if the player is grounded
    private bool _grounded;
    //Radius to check if the player can currently stand-up
    private const float _ceilingRadius = .2f;

    public void Crouch(bool crouch, float move)
    {

        if (!crouch)
        {
            // If there's a ceiling, the character won't stand up
            if (Physics2D.OverlapCircle(_ceilingCheck.position, _ceilingRadius, _whatIsGround))
            {
                crouch = true;
            }
        }

        // If crouching
        if (crouch)
        {
            // Disable one of the colliders when crouching
            if (_crouchDisableCollider != null)
                _crouchDisableCollider.enabled = false;
        }
        else
        {
            // Enable the collider when not crouching
            if (_crouchDisableCollider != null)
                _crouchDisableCollider.enabled = true;
        }
    }
}

