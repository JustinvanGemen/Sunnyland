using UnityEngine;

namespace PeppaSquad.Player
{
    public class PlayerClimb : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        //[SerializeField] private MovementPlayer _movementPlayer;
        [SerializeField] private float _climbingSpeed;
        private bool _climbingAround;
        private bool _climbing = false;
        public bool Climbing => _climbing;

        void OnTriggerEnter2D(Collider2D otherCol)
        {
            if (otherCol.tag == "Ladder")
            {
                _climbing = true;
                _rigidbody.velocity = new Vector2(0, 0);
            }
            if (otherCol.tag == "TopLadder")
            {
                _climbing = false;
            }
        }

        private void FixedUpdate()
        {
            if (_climbing)
            {
                print(_climbing);
                //_movementPlayer.enabled = false;
                Climb();
                _rigidbody.gravityScale = 0;
                _climbing = true;
            }
            else
            {
                _rigidbody.gravityScale = 1;
                //_movementPlayer.enabled = true;
                _climbing = false;
            }
        }

        private void Climb()
        {
            _climbingAround = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S);
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