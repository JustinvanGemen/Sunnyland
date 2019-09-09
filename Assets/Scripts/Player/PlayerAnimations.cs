using UnityEngine;

namespace PeppaSquad.Player
{
    public class PlayerAnimations : MonoBehaviour
    {
        //Other scripts required for animation conditions
        [SerializeField] private MovementPlayer _movement;
        [SerializeField] private PlayerDeath _playerDeath;
        [SerializeField] private PlayerFinish _playerFinish;
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
            //If the player has won, play the climbing animation(it looks like a dance in this case) and "ignore" the everything below inside of the function
            if (_playerFinish.Won)
            {
                _animator.SetBool("Climbing", true);
                return;
            }
            //If the player is not grounded, play the jumping animation and turn off idle.
            if (!_movement.Grounded)
            {
                _animator.SetBool("Jumping", true);
                _animator.SetBool("Idling", false);
            }
            //If the player is crouching, play the crouching animation and turn off idle.
            if (_movement.Crouching)
            {
                _animator.SetBool("Crouching", true);
                _animator.SetBool("Idling", false);
            }
            //If the player is running and grounded, play the running animation and turn off the idle
            if (_movement.Running && _movement.Grounded)
            {
                _animator.SetBool("Running", true);
                _animator.SetBool("Idling", false);
            }
            //if the player isn't doing anything, play idle animation
            if (!_movement.Running && _movement.Grounded && !_movement.Crouching)
            {
                _animator.SetBool("Idling", true);

                _animator.SetBool("Jumping", false);
                _animator.SetBool("Crouching", false);
                _animator.SetBool("Running", false);
            }
        }
    }
}
