using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerControls : MonoBehaviour
{
    public float velocity;
    public float torchDuration;

    float torchTimer = 0f;
    Light2D light2D;

    void Start()
    {
        light2D = GetComponent<Light2D>();
        light2D.enabled = false;
    }

    void Update()
    {
        HandleTorchTimer();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleTorchTimer()
    {
        if (torchTimer > 0f)
        {
            torchTimer -= Time.deltaTime;
            Debug.Log(torchTimer);
            if (torchTimer <= 0f)
            {
                light2D.enabled = false;
            }
        }
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0f, velocity * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0f, -1f * velocity * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1f * velocity * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(velocity * Time.deltaTime, 0f, 0f);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BreakableWall" && Input.GetKeyDown(KeyCode.R)) 
        {
            Destroy(collision.gameObject);
        }
    }

    public void GainTorch()
    {
        torchTimer = torchDuration;
        light2D.enabled = true;
    }
}
