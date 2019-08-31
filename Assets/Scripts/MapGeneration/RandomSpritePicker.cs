using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpritePicker : MonoBehaviour
{
    // 3, 9 14, 15, 16
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;
    void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
