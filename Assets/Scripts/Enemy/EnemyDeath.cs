using UnityEngine;

namespace PeppaSquad.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        //Used to be able to trigger the Dying animation
        [SerializeField] private Animator _animator;
        //To turn off the physical collider
        [SerializeField] private BoxCollider2D _collider;
        //Rigidbody of the object
        [SerializeField] private Rigidbody2D _rigidbody;


        /// <summary>
        ///  Triggered in PlayerDeath when the player collides with the enemy from above
        /// </summary>
        public void Death()
        {
            //Tells the animator that the dying animation should be played
            _animator.SetBool("Dying", true);
            //Turns off the physical collider
            _collider.enabled = false;
            //Freezes the rigidbody to keep it in place
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;

        }
    }
}
