using UnityEngine;

public class MovementController : MonoBehaviour
{
	//Force added to the player when they jump
	[SerializeField] private float _jumpForce;
	// % of speed while crouching, 0.01 = 1%
	[Range(0, 1)] [SerializeField] private float _crouchSpeed = .35f;
	//Smooths movement to make it less robotic
	[Range(0, .3f)] [SerializeField] private float _movementSmoothing = .05f;	
	//Decide if player can steer the character while jumping.
	[SerializeField] private bool _airControl = false;
	//Mask to determine what is ground
	[SerializeField] private LayerMask _whatIsGround;
	//Position marking if the player is grounded.
	[SerializeField] private Transform _groundCheck;							
	//Position to check for ceilings (to check if character must be force crouched)
	[SerializeField] private Transform _ceilingCheck;
	//Collider disabled when crouching.
	[SerializeField] private Collider2D _crouchDisableCollider;

	// Radius to determine if the character is currently grounded
	const float _groundedRadius = .2f; 
	//bool for checking if the player is grounded
	private bool _grounded;
	//Radius to check if the player can currently stand-up
	private const float _ceilingRadius = .2f;
	//The rigidbody of the player
	[SerializeField] private Rigidbody2D _rigidbody2D;
	//For determining which way the character is looking
	private bool _facingRight = true;  
	//Vector for Velocity!
	private Vector3 _velocity = Vector3.zero;



	private void FixedUpdate()
	{
		_grounded = false;

		// The player is grounded if a circle at the ground check position hits anything thats tagged as ground.
		// (You can do this using layers)
		Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, _groundedRadius, _whatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
				_grounded = true;
		}
	}


	public void Move(float move, bool crouch, bool jump)
	{
		// Checks if the character can stand up if they're crouching
		if (!crouch)
		{
			// If there's a ceiling, the character won't stand up
			if (Physics2D.OverlapCircle(_ceilingCheck.position, _ceilingRadius, _whatIsGround))
			{
				crouch = true;
			}
		}

		//Only able to control player if they're touching the ground, or if you've check AirControl in the inspector.
		if (_grounded || _airControl)
		{

			// If crouching
			if (crouch)
			{
				// Reduce the speed by the crouchSpeed multiplier
				move *= _crouchSpeed;

				// Disable one of the colliders when crouching
				if (_crouchDisableCollider != null)
					_crouchDisableCollider.enabled = false;
			} else
			{
				// Enable the collider when not crouching
				if (_crouchDisableCollider != null)
					_crouchDisableCollider.enabled = true;
			}

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, _rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			_rigidbody2D.velocity = Vector3.SmoothDamp(_rigidbody2D.velocity, targetVelocity, ref _velocity, _movementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !_facingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && _facingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (_grounded && jump)
		{
			// Add a vertical force to the player.
			_grounded = false;
			_rigidbody2D.AddForce(new Vector2(0f, _jumpForce));
		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		_facingRight = !_facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}