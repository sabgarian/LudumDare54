using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Lever.Color doorColor;
    public bool defaultOpen = false;
    public Sprite[] doorClosedSprites = new Sprite[3];
    public Sprite[] doorOpenSprites = new Sprite[3];

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
        boxCollider2D.enabled = false;
        spriteRenderer.sprite = doorOpenSprites[(int)doorColor];
    }

    void Close()
    {
        boxCollider2D.enabled = true;
        spriteRenderer.sprite = doorClosedSprites[(int)doorColor];
    }
}
