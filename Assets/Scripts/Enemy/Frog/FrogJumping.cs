using System.Collections;
using UnityEngine;

namespace PeppaSquad.Enemy.Frog
{
    public class FrogJumping : MonoBehaviour
    {
        //The animator of the object
        [SerializeField] private Animator _animator;

        //The sprite renderer of the object
        [SerializeField] private SpriteRenderer _spriteRenderer;

        //The rigidbody of the object
        [SerializeField] private Rigidbody2D _rigidbody2D;

        //The force at which the object propels itself upwards.
        [SerializeField] private float _jumpForce;

        //The layer which is marked as being ground
        [SerializeField] private LayerMask _whatIsGround;

        //The transform used to check for nearby ground
        [SerializeField] private Transform _groundCheck;

        //The force at which the object propels itself horizontally
        [SerializeField] private float _verticalForce;

        //Radius for the groundcheck
        private const float _groundedRadius = .2f;

        //Bool to track if the object is currently touching the ground
        private bool _grounded;

        //Bool to track what way the object is facing
        private bool _facingRight;

        ///<summary>
        ///At the start of the game, start the coroutine Jump (Found at the bottom of the script).
        ///</summary>
        private void Start()
        {
            StartCoroutine(Jump());
        }

        ///<summary>
        /// Update goes off once per frame, and if the object is currently grounded, it is set to Idling in the animator.
        ///</summary>
        private void Update()
        {
            if (_grounded)
            {
                _animator.SetBool("Idling", true);
            }
        }

        ///<summary>
        /// When entering another collider thats set to trigger, it compares the tag of the other gameobject to TurnAI. If they're the same, it triggers the if statement.
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
        /// Simply flips the sprite around. flipX becomes false if its true, and true if its false.
        ///</summary>
        private void FlipSprite()
        {
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }

        ///<summary>
        ///FixedUpdate gets called 50 times per second, no matter the framerate. This makes it good for physics. In this script its used to check if the object is touching the ground.
        ///</summary>
        private void FixedUpdate()
        {
            _grounded = false;

            // The character is grounded if a circle at the ground check position hits anything thats tagged as ground.
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
        ///Coroutine to take care of the frog jumping and to make sure the correct animation is being played.
        ///</summary>
        private IEnumerator Jump()
        {
            //While is used to repeat the coroutine 
            while (true)
            {
                //Turns off the jumping animation
                _animator.SetBool("Jumping", false);
                //Waits for 3 and a half seconds before continueing.
                yield return new WaitForSeconds(3.5f);
                //Turns on the jumping animation, and turns off the idling animation
                _animator.SetBool("Jumping", true);
                _animator.SetBool("Idling", false);
                //Checks what way the character is facing before adding both horizontal and vertical forces to make the frog jump.
                if (_facingRight)
                {
                    _rigidbody2D.AddForce(new Vector2(_verticalForce, _jumpForce));
                }
                else
                {
                    _rigidbody2D.AddForce(new Vector2(-_verticalForce, _jumpForce));
                }
                //Wait half a second before repeating from the top
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
