using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class PlayerControls : MonoBehaviour
{
    public float velocity;
    public float torchDuration;
    public bool canMove = true;

    public GameOverScreen GameOverScreen;
    public VictoryScript VictoryScript;

    public int health = 3;
    private bool takingDamage = false;
    private int damageTimer = 5;

    float torchTimer = 0f;
    Light2D light2D;
    int pickaxeCount = 0;

    void Start()
    {
        light2D = GetComponent<Light2D>();
        light2D.enabled = false;
    }

    void Update()
    {
        HandleTorchTimer();
        damageTimer--;
        if(damageTimer <= 0)
        {
            canMove = true;
            takingDamage = false;
            damageTimer = 5;
        }
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
            if (torchTimer <= 0f)
            {
                light2D.enabled = false;
            }
        }
    }

    void HandleMovement()
    {
        if (!canMove)
        {
            return;
        }

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

    public void OnCollisionEnter2D(Collision2D other)
    {
        UnityEngine.Debug.Log(health);
        
    }
    
    public void TakeDamage()
    {
        health--;
        takingDamage = true;
        canMove = false;

        if (health <= 0)
        {
            Destroy(gameObject);
            //Game over
        }
    }

    public void OnCollisionStay2D(Collision2D other)
    {
        if (
            other.gameObject.CompareTag("BreakableWall")
            && Input.GetKeyDown(KeyCode.E)
            && pickaxeCount > 0
        )
        {
            Vector3Int point =
                new(
                    (int)(other.GetContact(0).point.x / 2f),
                    (int)(other.GetContact(0).point.y / 2f)
                );
            Tilemap tilemap = other.gameObject.GetComponent<Tilemap>();
            tilemap.SetTile(point, null);
            pickaxeCount--;
        }
        //Eventually, the Player will need to stop moving if they touch a wall of any kind (the wall serves as a solid barrier)
        else if (other.gameObject.tag == "BreakableWall" || other.gameObject.tag == "IndestructableWall"){

        }
    }

    public void GainTorch()
    {
        torchTimer = torchDuration;
        light2D.enabled = true;
    }

    public void GainPickaxe()
    {
        pickaxeCount++;
    }
}
