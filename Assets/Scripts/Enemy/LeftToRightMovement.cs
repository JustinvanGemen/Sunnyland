using UnityEngine;

public class LeftToRightMovement : MonoBehaviour
{
    [SerializeField] private float _walkingSpeed = 1;
    private bool _facingRight = false;
    [SerializeField] private SpriteRenderer _spriteRenderer;


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
}
