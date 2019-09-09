using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    //Used to be able to trigger the Dying animation
    [SerializeField] private Animator _animator;
    //To turn off the physical collider
    [SerializeField] private BoxCollider2D _collider;
    //To turn off a kill collider
    [SerializeField] private BoxCollider2D _triggerCollider;
    //Rigidbody of the object
    [SerializeField] private Rigidbody2D _rigidbody;

    ///<summary>
    /// OnTriggerEnter used to see when the Enemy hits an object with the tag "Kill". This is a collider around the position of the players feet.
    ///</summary>
    private void OnTriggerEnter2D(Collider2D otherCol)
    {
        //Checks if the other collider has the tag "Kill"
        if (otherCol.tag == "Kill")
        {
            //Tells the animator that the dying animation should be played
            _animator.SetBool("Dying", true);
            //Turns off the physical collider
            _collider.enabled = false;
            //Turns off the trigger collider
            _triggerCollider.enabled = false;
            //Freezes the rigidbody to keep it in place
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
