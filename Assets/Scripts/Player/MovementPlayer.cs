using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private MovementController _movementController;
    [SerializeField] private PlayerJump _playerJump;
    [SerializeField] private PlayerCrouch _playerCrouch;

    private float _movementSpeed = 15f;
    private float _horizontalMove = 0f;
    private bool _jumping = false;
    private bool _crouching = false;
    private bool _running = false;

    public bool Running => _running;
    public bool Grounded => _playerJump.Grounded;
    public bool Crouching => _crouching;

    private void Update()
    {
        if (!_crouching)
        {
            _horizontalMove = Input.GetAxisRaw("Horizontal") * _movementSpeed;
            _running = Input.GetAxisRaw("Horizontal") != 0;
        }
        _jumping = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow);
        _crouching = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
    }

    private void FixedUpdate()
    {
        float speed = _horizontalMove * Time.fixedDeltaTime;
        _movementController.Move(speed);
        _playerJump.Jump(_jumping);
        _playerCrouch.Crouch(_crouching, speed);
        _jumping = false;
    }
}