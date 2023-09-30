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
        Lever.OnLeverActivated.AddListener(ChangeState);
    }

    void OnDisable()
    {
        Lever.OnLeverActivated.RemoveListener(ChangeState);
    }

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Lever.leverColors[(int)doorColor];
        isOpen = defaultOpen;
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
    }

    void Close()
    {
        boxCollider2D.enabled = true;
    }
}
