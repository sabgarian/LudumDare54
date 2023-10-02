using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class PlayerControls : MonoBehaviour
{
    public float velocity;
    public float torchDuration;
    public bool canMove = true;
    public int pickaxeCount = 0;

    public GameOverScreen GameOverScreen;
    public VictoryScript VictoryScript;

    float torchTimer = 0f;
    Light2D light2D;
    Animator animatorController;

    void Start()
    {
        light2D = GetComponent<Light2D>();
        animatorController = GetComponent<Animator>();
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

        float vertChange = 0;
        float horizontalChange = 0;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            vertChange += velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
			vertChange -= velocity * Time.deltaTime;
		}
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            horizontalChange -= velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            horizontalChange += velocity * Time.deltaTime;
        }

        animatorController.SetFloat("vChange", vertChange);
        animatorController.SetFloat("hChange", horizontalChange);
        animatorController.SetBool("isWalking", Mathf.Abs(vertChange) > Mathf.Epsilon || Mathf.Abs(horizontalChange) > Mathf.Epsilon);
        animatorController.SetBool("walkingH", Mathf.Abs(horizontalChange) > Mathf.Epsilon);

        transform.position += new Vector3(horizontalChange, vertChange);
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
