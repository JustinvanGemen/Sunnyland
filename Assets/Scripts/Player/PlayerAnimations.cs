using UnityEngine;

namespace PeppaSquad.Player
{
    public class PlayerAnimations : MonoBehaviour
    {
        //Other scripts required for animation conditions
        [SerializeField] private MovementPlayer _playerMovement;
        [SerializeField] private PlayerDeath _playerDeath;
        [SerializeField] private PlayerJump _playerJump;
        [SerializeField] private PlayerFinish _playerFinish;
        [SerializeField] private PlayerClimb _playerClimbing;
        //The animator in charge of the player animations
        [SerializeField] private Animator _animator;

        /// <summary>
        ///  Update constantly checks if any of the conditions have change to play the correct animation at all times
        /// </summary>
        private void Update()
        {
            //If the player is dead, play the hurt animation and "ignore" the everything below inside of the function
            if (_playerDeath.Dead)
            {
                _animator.SetBool("Hurting", true);
                return;
            }

            //If the player is climbing, play the climbing animation.
            if (_playerClimbing.Climbing)
            {
                _animator.SetBool("Climbing", true);
                _animator.SetBool("Jumping", false);
                _animator.SetBool("Running", false);
                _animator.SetBool("Idling", false);
                return;
            }
            if (!_playerClimbing.Climbing)
            {
                _animator.SetBool("Climbing", false);
            }
            //If the player is not grounded, play the jumping animation and turn off idle.
            if (!_playerJump.Grounded)
            {
                _animator.SetBool("Jumping", true);
                _animator.SetBool("Running", false);
                _animator.SetBool("Idling", false);
            }
            //If the player is crouching, play the crouching animation and turn off idle.
            if (_playerMovement.Crouching)
            {
                _animator.SetBool("Crouching", true);
                _animator.SetBool("Idling", false);
            }
            //If the player is running and grounded, play the running animation and turn off the idle
            if (_playerMovement.Running && _playerJump.Grounded)
            {
                _animator.SetBool("Running", true);
                _animator.SetBool("Idling", false);
            }
            //if the player isn't doing anything, play idle animation
            if (!_playerMovement.Running && _playerJump.Grounded && !_playerMovement.Crouching)
            {
                _animator.SetBool("Idling", true);
                _animator.SetBool("Jumping", false);
                _animator.SetBool("Crouching", false);
                _animator.SetBool("Running", false);
            }
        }
    }
}
