using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    public enum Color
    {
        Red,
        Blue,
        Yellow
    }

    public static UnityEvent<Color> OnLeverActivated = new();

    public static readonly Color32[] leverColors =
    {
        new Color32(255, 0, 0, 255),
        new Color32(0, 0, 255, 255),
        new Color32(255, 255, 0, 255)
    };

    public Color color;
    public Sprite leverUp,
        leverDown;

    bool isInteractable = false;
    bool isActivated = false;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = leverUp;
        spriteRenderer.color = leverColors[(int)color];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isInteractable = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isInteractable = false;
    }

    void Update()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.E) && !isActivated)
        {
            Interact();
        }
    }

    void Interact()
    {
        isActivated = true;
        spriteRenderer.sprite = leverDown;
        OnLeverActivated?.Invoke(color);
    }
}
