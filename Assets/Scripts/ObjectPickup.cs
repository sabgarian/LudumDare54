using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type { Torch, Idol }
public class ObjectPickup : MonoBehaviour
{
    private bool isPickedUp = false;
    void Update()
    {
        if (isPickedUp)
        {
            if (this.gameObject.tag.Equals("Torch")){

            }
            if (this.gameObject.tag.Equals("Idol")){

            }
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
