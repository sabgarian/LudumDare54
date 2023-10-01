using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Lever.Color doorColor;
    public bool defaultOpen = false;

    bool isOpen = false;
    BoxCollider2D boxCollider2D;
    SpriteRenderer spriteRenderer;

    void OnEnable()
    {
        Lever.OnLeverActivated += ChangeState;
    }

    void OnDisable()
    {
        Lever.OnLeverActivated -= ChangeState;
    }

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Lever.leverColors[(int)doorColor];
        Debug.Log(spriteRenderer.color);
        isOpen = defaultOpen;
        if (isOpen)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    void ChangeState(Lever.Color col)
    {
        if (col != doorColor)
        {
            return;
        }

        isOpen = !isOpen;

        if (isOpen)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    void Open()
    {
        Debug.Log(doorColor + " door is open");
        boxCollider2D.enabled = false;
        spriteRenderer.color = new Color(
            spriteRenderer.color.r,
            spriteRenderer.color.g,
            spriteRenderer.color.b,
            0.5f
        );
    }

    void Close()
    {
        boxCollider2D.enabled = true;
        spriteRenderer.color = new Color(
            spriteRenderer.color.r,
            spriteRenderer.color.g,
            spriteRenderer.color.b,
            1f
        );
    }
}
