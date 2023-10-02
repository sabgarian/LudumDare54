using System.Collections;
using System.Collections.Generic;
//using System.Media;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float velocity = 2.0f;
    public bool isVertical;
    private bool facingPos = true;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (isVertical)
        {
            if (facingPos)
            {
                transform.position += new Vector3(0f, velocity * Time.deltaTime, 0f);
            }
            else
            {
                transform.position += new Vector3(0f, -1f * velocity * Time.deltaTime, 0f);
            }
        }
        else
        {
            if (facingPos)
            {
                transform.position += new Vector3(velocity * Time.deltaTime, 0f, 0f);
            }
            else
            {
                transform.position += new Vector3(-1f * velocity * Time.deltaTime, 0f, 0f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("IndestructableWall"))
        {
            facingPos = !facingPos;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerControls>().TakeDamage();
        }
    }
}
