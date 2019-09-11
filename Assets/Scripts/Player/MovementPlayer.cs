using UnityEngine;

namespace PeppaSquad.Player
{
    public class MovementPlayer : MonoBehaviour
    {
        //Other scripts involved in controlling the player, assigned in the inspector
        [SerializeField] private MovementController _movementController;
        [SerializeField] private PlayerJump _playerJump;
        [SerializeField] private PlayerCrouch _playerCrouch;
        [SerializeField] private PlayerClimb _playerClimb;

        //Floats that influence the way the player moves
        [SerializeField] private float _movementSpeed = 15f;
        [SerializeField] private float _horizontalMove = 0f;
        //private bools that track whether the player is currently acting
        private bool _jumping = false;
        private bool _crouching = false;
        private bool _running = false;
        //Public bools equal to the private bools. 
        public bool Running => _running;
        public bool Grounded => _playerJump.Grounded;
        public bool Crouching => _crouching;

        /// <summary>
        ///  Update is called every frame. Takes care of input.
        /// </summary>
        private void Update()
        {
            //Checks if the player is not crouching before allowing horizontal movement
            if (!_playerClimb.Climbing)
            {
                if (!_crouching)
                {
                    _horizontalMove = Input.GetAxisRaw("Horizontal") * _movementSpeed;
                    _running = Input.GetAxisRaw("Horizontal") != 0;
                    //Activates jumping with the keycodes listed
                    _jumping = Input.GetKeyDown(KeyCode.Space);
                    //activates crouching with the keycodes listed  
                    _playerJump.Jump(_jumping);
                }
                _crouching = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
            }

        }

        /// <summary>
        ///  Takes care of calculating the speed for movement
        /// </summary>
        private void FixedUpdate()
        {
            float speed = _horizontalMove * Time.fixedDeltaTime;
            _movementController.Move(speed);
            if (!_playerClimb.Climbing)
            {
                _playerCrouch.Crouch(_crouching, speed);
            }
            _jumping = false;
        }
    }
}