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

    public static UnityAction<Color> OnLeverActivated;

    public Color color;
    public Sprite[] leverUp,
        leverDown;

    bool isInteractable = false;
    bool isActivated = false;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = leverUp[(int)color];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }

        isInteractable = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
        isInteractable = false;
    }

    void Update()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void Interact()
    {
        isActivated = !isActivated;
        spriteRenderer.sprite = isActivated ? leverDown[(int)color] : leverUp[(int)color];
        OnLeverActivated?.Invoke(color);
    }
}
