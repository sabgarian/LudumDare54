using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchPickup : MonoBehaviour
{
    private bool isPickedUp = false;
    void Update()
    {
        if (isPickedUp)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            isPickedUp = true;
        }
    }
}
