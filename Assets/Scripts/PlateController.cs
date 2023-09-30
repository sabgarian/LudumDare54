using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    [SerializeField] private GameObject _rubble;
    [SerializeField] private Vector2 _rubbleposition;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") { 
            GameObject obj = Instantiate(_rubble);
            obj.transform.position = _rubbleposition;
        }
    }
}
