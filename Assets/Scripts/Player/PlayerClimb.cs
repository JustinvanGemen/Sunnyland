using UnityEngine;

namespace PeppaSquad.Player
{
    public class PlayerClimb : MonoBehaviour
    {
        //Rigidbody of the player
        [SerializeField] private Rigidbody2D _rigidbody;
        //The speed at which the player can go up/down
        [SerializeField] private float _climbingSpeed;
        //If the player is currently moving while climbing
        private bool _climbingAround;
        //private bool that tracks if the player is on a ladder
        private bool _climbing = false;
        //public bool that is equal to _climbing
        public bool Climbing => _climbing;

        /// <summary>
        /// When entering a ladders trigger area, player automatically begins climbing
        /// </summary>

        void OnTriggerEnter2D(Collider2D otherCol)
        {
            //If its a ladder, start climbing
            if (otherCol.tag == "Ladder")
            {
                _climbing = true;
                _rigidbody.velocity = new Vector2(0, 0);
            }
            //if the other collider is the top of the ladder, stop climbing
            if (otherCol.tag == "TopLadder")
            {
                _climbing = false;
            }
        }
        /// <summary>
        /// If the player is climbing, the gravityscale gets put on 0 and the player gets access to climb-control. If the player isn't climbng, reverse the effect of climbing
        /// </summary>

        private void FixedUpdate()
        {
            if (_climbing)
            {
                Climb();
                _rigidbody.gravityScale = 0;
                _climbing = true;
            }
            else
            {
                _rigidbody.gravityScale = 1;
                _climbing = false;
            }
        }

        /// <summary>
        /// Takes care of the climb-controls
        /// </summary>
        private void Climb()
        {
            _climbingAround = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S);
            //W makes you go up by the amount of _climbingspeed. S makes you go down with the same speed as you can go up.
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, _climbingSpeed, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= new Vector3(0, _climbingSpeed, 0);
            }
        }
    }
}