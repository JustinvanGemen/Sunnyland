using UnityEngine;

namespace PeppaSquad.Player
{
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

        ///<summary>
        /// Referenced in MovementPlayer. Takes care of crouching
        ///</summary>
        public void Crouch(bool crouch, float move)
        {

            //If the player isn't crouching, but theres an object within the ceiling radius of the players head, the player starts crouching without any input being required
            if (!crouch)
            {
                // If there's a ceiling, the character won't stand up
                if (Physics2D.OverlapCircle(_ceilingCheck.position, _ceilingRadius, _whatIsGround))
                {
                    crouch = true;
                }
            }

            // If the player is crouching, disable the head collider on the players head. Otherwise turn it on.
            if (crouch)
            {
                // Disable head collider when crouching
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
}

