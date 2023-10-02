using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    public float velocity;
    public float torchDuration;
    public bool canMove = true;
    public bool hasPickaxe = false;

    public GameOverScreen GameOverScreen;
    public ItemHUD pickaxeHUD,
        torchHUD;

    public int health = 3;
    private bool takingDamage = false;
    public static float damageTimeSetting = 1f;
    private float damageTimer = damageTimeSetting;

    private Rigidbody2D playerRB;

    float torchTimer = 0f;
    bool canBreakWall = false;
    Light2D light2D;
    Animator animatorController;
    HealthHUD healthHUD;
    SpriteRenderer spriteRenderer;
    Vector2 velocityVector;

    void Start()
    {
        light2D = GetComponent<Light2D>();
        animatorController = GetComponent<Animator>();
        light2D.enabled = false;
        playerRB = GetComponent<Rigidbody2D>();
        healthHUD = FindObjectOfType<HealthHUD>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        healthHUD.UpdateHUD(health);
    }

    void Update()
    {
        HandleTorchTimer();
        if (takingDamage)
        {
            damageTimer -= Time.deltaTime;
            if (damageTimer <= 0)
            {
                canMove = true;
                takingDamage = false;
                damageTimer = damageTimeSetting;
                spriteRenderer.color = Color.white;
            }
        }
        if (canBreakWall && Input.GetKeyDown(KeyCode.E))
        {
            BreakWall();
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("SampleScene");
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
                torchHUD.LoseItem();
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
        animatorController.SetBool(
            "isWalking",
            Mathf.Abs(vertChange) > Mathf.Epsilon || Mathf.Abs(horizontalChange) > Mathf.Epsilon
        );
        animatorController.SetBool("walkingH", Mathf.Abs(horizontalChange) > Mathf.Epsilon);

        velocityVector = new Vector2(horizontalChange, vertChange);

        transform.position += (Vector3)velocityVector;
    }

    public void TakeDamage(Rigidbody2D enemyBody)
    {
        if (takingDamage)
        {
            return;
        }

        Vector3 direction;
        health--;
        takingDamage = true;
        canMove = false;
        direction = playerRB.transform.position - enemyBody.transform.position;
        spriteRenderer.color = Color.gray;
        playerRB.AddForce(direction.normalized * 300f);

        healthHUD.UpdateHUD(health);

        if (health <= 0)
        {
            Destroy(gameObject);
            GameOverScreen.gameObject.SetActive(true);
            GameOverScreen.TriggerGameOver(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BreakableWall"))
        {
            canBreakWall = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BreakableWall"))
        {
            canBreakWall = false;
        }
    }

    void BreakWall()
    {
        Vector3 pointWorldSpace = transform.position + ((Vector3)velocityVector).normalized;
        Vector3Int point = new((int)(pointWorldSpace.x / 2f), (int)(pointWorldSpace.y / 2f));
        Tilemap tilemap = GameObject.FindGameObjectWithTag("BreakableWall").GetComponent<Tilemap>();
        tilemap.SetTile(point, null);
        hasPickaxe = false;
        pickaxeHUD.LoseItem();
    }

    public void GainTorch()
    {
        torchTimer = torchDuration;
        light2D.enabled = true;
        torchHUD.GainItem();
    }

    public void GainPickaxe()
    {
        hasPickaxe = true;
        pickaxeHUD.GainItem();
    }
}
