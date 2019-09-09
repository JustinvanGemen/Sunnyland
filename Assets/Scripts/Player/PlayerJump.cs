using UnityEngine;

namespace PeppaSquad.Player
{
    public class PlayerJump : MonoBehaviour
    {
        //Force added to the player when they jump
        [SerializeField] private float _jumpForce;

        //Decide if player can steer the character while jumping.
        [SerializeField] private bool _airControl;

        //Mask to determine what is ground
        [SerializeField] private LayerMask _whatIsGround;

        //Position marking if the player is grounded.
        [SerializeField] private Transform _groundCheck;

        //The rigidbody of the player
        [SerializeField] private Rigidbody2D _rigidbody2D;

        // Radius to determine if the character is currently grounded
        private const float _groundedRadius = .2f;

        //bool for checking if the player is grounded
        private bool _grounded;
        //Public bool that is equal to _grounded
        public bool Grounded => _grounded;
        ///<summary>
        /// This FixedUpdate is used to check if the player is touching the ground
        ///</summary>
        private void FixedUpdate()
        {
            _grounded = false;

            // The player is grounded if a circle at the ground check position hits anything thats tagged as ground.
            // (You can do this using layers)
            Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, _groundedRadius, _whatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    _grounded = true;

                }

            }
        }
        ///<summary>
        ///This function gets called in PlayerMovement. It takes care of the actual jumping.
        ///</summary>
        public void Jump(bool jump)
        {
            if (_grounded || _airControl)
            {
                // If the player should jump...
                if (_grounded && jump)
                {
                    // Add a vertical force to the player.
                    _grounded = false;

                    _rigidbody2D.AddForce(new Vector2(0f, _jumpForce));
                }
            }
        }
    }
}
