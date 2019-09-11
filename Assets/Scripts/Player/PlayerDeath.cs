using UnityEngine;
using PeppaSquad.Enemy;

namespace PeppaSquad.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        //Death menu object to enable when the player dies
        [SerializeField] private GameObject _deathMenu;
        //Spriterenderer is used to change the alpha of the gameobject
        [SerializeField] private SpriteRenderer _spriteRenderer;
        //MovementPlayer is used to turn off the controls when the player dies
        [SerializeField] private MovementPlayer _movementPlayer;
        //Private boolean to track if the player is dead or alive
        private bool _dead = false;
        //Public boolean that mirrors the private boolean "_dead". This can be accessed in other scripts.
        public bool Dead => _dead;

        /// <summary>
        ///   2d collision check
        /// </summary>
        void OnCollisionEnter2D(Collision2D collision)
        {
            //Checks if the collision is the invisible deathzone beneath the map (Player hits it when falling off the map)
            if (collision.collider.tag == "Kill")
            {
                PlayerDied();
            }
            //Checks if the non-player collider involved is not an enemy
            if (collision.collider.tag != "Enemy")
            {
                //If its not, return 
                return;
            }
            //If the other collider was an enemy, take the relativevelocity X and Y, make them positive and check if X is bigger than Y.
            if (Mathf.Abs(collision.relativeVelocity.x) > Mathf.Abs(collision.relativeVelocity.y))
            {
                //If the X was bigger than Y, the player did not collide from above and dies
                PlayerDied();
            }
            else
            {
                //If the Y was bigger than X, the player collided with the enemy from above, and the enemy dies

                //gets the enemy death component from the non-player collider and then triggers the death function on that script
                var enemyDeath = collision.collider.gameObject.GetComponent<EnemyDeath>();
                enemyDeath.Death();
            }
        }

        /// <summary>
        ///  This gets triggered when the player dies in a collision
        /// </summary>

        private void PlayerDied()
        {
            //Creating a temporary color thats equal to the players current color
            Color tempColor = _spriteRenderer.color;
            //Changing the alpha to be slightly more transparent
            tempColor.a = 0.7f;
            //Changing the players current color to be equal to the temporary color
            _spriteRenderer.color = tempColor;
            //Setting the tracker to true, to indicate that the player has perished.
            _dead = true;
            //Turning off the players movement, and activating the death menu to let the player return to the main screen.
            _movementPlayer.enabled = false;
            _deathMenu.SetActive(true);
        }
    }
}
