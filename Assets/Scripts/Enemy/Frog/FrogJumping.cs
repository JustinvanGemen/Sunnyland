using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogJumping : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private Rigidbody2D _rigidbody2D;

    [SerializeField] private float _jumpForce;

    [SerializeField] private LayerMask _whatIsGround;

    [SerializeField] private Transform _groundCheck;

    private const float _groundedRadius = .2f;

    private bool _grounded;

    private bool _facingRight;

    private void Start()
    {
        StartCoroutine(Jump());
    }

    private void Update()
    {
        if (_grounded)
        {
            _animator.SetBool("Idling", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCol)
    {
        if (otherCol.tag == "TurnAI")
        {
            _facingRight = !_facingRight;
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }

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

    private IEnumerator Jump()
    {
        _animator.SetBool("Jumping", false);
        yield return new WaitForSeconds(3.5f);
        _animator.SetBool("Jumping", true);
        _animator.SetBool("Idling", false);
        if (_facingRight)
        {
            _rigidbody2D.AddForce(new Vector2(50f, _jumpForce));
        }
        else
        {
            _rigidbody2D.AddForce(new Vector2(-50f, _jumpForce));
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Jump());
    }
}
