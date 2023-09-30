using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField]
    Sprite leverUp,
        leverDown;

    bool isInteractable = false;
    bool isActivated = false;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = leverUp;
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
    }
}
