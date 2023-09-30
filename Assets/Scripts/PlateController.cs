using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") { 
            Destroy(_door);
        }
    }
}
