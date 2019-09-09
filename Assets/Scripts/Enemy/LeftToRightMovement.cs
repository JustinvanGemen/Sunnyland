using UnityEngine;

namespace PeppaSquad.Enemy
{
    public class LeftToRightMovement : MonoBehaviour
    {
        //The speed at which the AI moves
        [SerializeField] private float _walkingSpeed = 1;
        //Bool for tracking which way the AI is facing
        private bool _facingRight = false;
        //Spriterenderer (Used for turning the sprite around)
        [SerializeField] private SpriteRenderer _spriteRenderer;


        ///<summary>
        /// Moves the AI by a set speed based on the direction they're facing
        ///</summary>
        private void Update()
        {
            if (_facingRight)
            {
                transform.Translate(Vector2.right * _walkingSpeed * Time.deltaTime);
            }
            if (!_facingRight)
            {
                transform.Translate(-Vector2.right * _walkingSpeed * Time.deltaTime);
            }
        }

        ///<summary>
        /// When triggering, and the other collider has the tag "TurnAI", turn around
        ///</summary>
        private void OnTriggerEnter2D(Collider2D otherCol)
        {
            if (otherCol.tag == "TurnAI")
            {
                _facingRight = !_facingRight;
                FlipSprite();
            }
        }

        ///<summary>
        /// Flips the objects sprite.
        ///</summary>
        private void FlipSprite()
        {
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }
    }
}
