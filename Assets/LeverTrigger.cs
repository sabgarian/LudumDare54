using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class LeverTrigger : MonoBehaviour
{
    //private bool displayKey;
    SpriteRenderer key;

    void Start()
    {
        key = GetComponent<SpriteRenderer>();
        key.enabled = false;
    }

    void Update()
    {

    }   
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            key.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            key.enabled = false;
        }
    }
}
