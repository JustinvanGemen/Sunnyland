using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject _deathMenu;
    void OnTriggerEnter2D(Collider2D otherCol)
    {
        if (otherCol.tag == "Enemy")
        {
            var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            var playerMovement = gameObject.GetComponent<MovementPlayer>();
            Color tempColor = spriteRenderer.color;
            tempColor.a = 0.3f;
            spriteRenderer.color = tempColor;
            playerMovement.enabled = false;
            _deathMenu.SetActive(true);

        }
    }
}
