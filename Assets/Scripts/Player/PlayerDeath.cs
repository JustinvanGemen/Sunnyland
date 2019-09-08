using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject _deathMenu;
    //Private boolean to track if the player is dead or alive
    private bool _dead = false;
    //Public boolean that mirrors the private boolean "_dead". This can be accessed in other scripts.
    public bool Dead => _dead;

    //2d collider check, when colliding with a collider thats set to "Is trigger" in the inspector.
    void OnTriggerEnter2D(Collider2D otherCol)
    {
        //Compares the tag of the other object to "Enemy", if its true(if the other tag is indeed Enemy), it continues into the if statement.
        if (otherCol.tag == "Enemy")
        {
            //Getting a few components from the gameobject to turn them off/change settings
            var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            var playerMovement = gameObject.GetComponent<MovementPlayer>();
            //Creating a temporary color thats equal to the players current color
            Color tempColor = spriteRenderer.color;
            //Changing the alpha to be slightly more transparent
            tempColor.a = 0.7f;
            //Changing the players current color to be equal to the temporary color
            spriteRenderer.color = tempColor;
            //Setting the tracker to true, to indicate that the player has perished.
            _dead = true;
            //Turning off the players movement, and activating the death menu to let the player return to the main screen.
            playerMovement.enabled = false;
            _deathMenu.SetActive(true);

        }
    }
}
