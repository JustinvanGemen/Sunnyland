using UnityEngine;

public class RandomSpritePicker : MonoBehaviour
{
    //Spriterenderer of the object to randomize
    [SerializeField] private SpriteRenderer spriteRenderer;
    //An array of sprites to choose from
    [SerializeField] private Sprite[] sprites;

    ///<summary>
    /// At the start of the game, chooses a random sprite from the array for the spriterenderer to display. Its currently used for the dirt ground of the level.
    ///</summary>
    void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
