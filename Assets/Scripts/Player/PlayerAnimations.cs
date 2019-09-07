using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private MovementPlayer _movement;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (_movement.Jumping)
        {
            _animator.SetBool("Jumping", true);
            _animator.SetBool("Idling", false);
        }
        if (_movement.Crouching)
        {
            _animator.SetBool("Crouching", true);
            _animator.SetBool("Idling", false);
        }
        if (_movement.Running && !_movement.Jumping)
        {
            _animator.SetBool("Running", true);
            _animator.SetBool("Idling", false);
        }
        if (!_movement.Running && !_movement.Jumping && !_movement.Crouching)
        {
            _animator.SetBool("Idling", true);

            _animator.SetBool("Jumping", false);
            _animator.SetBool("Crouching", false);
            _animator.SetBool("Running", false);
        }
    }
}
