using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlateController : MonoBehaviour
{
    [SerializeField]
    private Sprite _rubble;

    void Start()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().sprite = _rubble;
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
