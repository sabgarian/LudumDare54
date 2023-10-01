using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ObjectPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Effect();
            Destroy(gameObject);
        }
    }

    public virtual void Effect()
    {
        Debug.Log("Effect not implemented");
    }
}
