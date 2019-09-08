using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private MovementPlayer _movement;
    [SerializeField] private PlayerDeath _playerDeath;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (_playerDeath.Dead)
        {
            _animator.SetBool("Hurting", true);
            return;
        }
        if (!_movement.Grounded)
        {
            _animator.SetBool("Jumping", true);
            _animator.SetBool("Idling", false);
        }
        if (_movement.Crouching)
        {
            _animator.SetBool("Crouching", true);
            _animator.SetBool("Idling", false);
        }
        if (_movement.Running && _movement.Grounded)
        {
            _animator.SetBool("Running", true);
            _animator.SetBool("Idling", false);
        }
        if (!_movement.Running && _movement.Grounded && !_movement.Crouching)
        {
            _animator.SetBool("Idling", true);

            _animator.SetBool("Jumping", false);
            _animator.SetBool("Crouching", false);
            _animator.SetBool("Running", false);
        }
    }
}
