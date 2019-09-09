using UnityEngine;

namespace PeppaSquad.Player
{
    public class MovementController : MonoBehaviour
    {
        //Smooths movement to make it less robotic
        [Range(0, .3f)] [SerializeField] private float _movementSmoothing = .05f;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        //For determining which way the character is looking
        private bool _facingRight = true;
        //Vector for Velocity!
        private Vector3 _velocity = Vector3.zero;

        /// <summary>
        ///  Takes care of moving the player
        /// </summary>
        public void Move(float move)
        {

            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, _rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            _rigidbody2D.velocity = Vector3.SmoothDamp(_rigidbody2D.velocity, targetVelocity, ref _velocity, _movementSmoothing);

            // Flip the player based on input so that the player visually faces the correct direction
            if (move > 0 && !_facingRight || move < 0 && _facingRight)
            {
                //flip the player.
                Flip();
            }


        }
        /// <summary>
        ///  Flips the player to face the direction where the player is moving.
        /// </summary>
        private void Flip()
        {
            // Flips the sprite
            _facingRight = !_facingRight;

            // Multiply the player's x local scale by -1.
            Vector3 playerLocalScale = transform.localScale;
            playerLocalScale.x *= -1;
            transform.localScale = playerLocalScale;
        }
    }
}