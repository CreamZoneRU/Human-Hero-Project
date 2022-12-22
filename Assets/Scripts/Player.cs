using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enemy;

public class Player : MonoBehaviour
{
    // Private Components
    [SerializeField] Rigidbody2D playerRb;

    // Public Components
    public HealthBar healthBar;

    // Private Variables


    // Public Variables
    Vector2 playerMovement;


    [Serializable] 
    public class PlayerStats
    {
        public int maxHealth = 10;
        public int currentHealth;
        public float speed = 7f;
        public int strength = 10;
    }

    public PlayerStats playerStats = new PlayerStats();

    void Start()
    {
        // Setting player's health to max at start
        playerStats.currentHealth = playerStats.maxHealth;
        healthBar.SetMaxHealth(playerStats.maxHealth);
    }


    // Update is called once per frame
    void Update()
    {
        // Captures the horizontal and vertical input
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Moves the character to the specified point by pressing the control buttons
        playerRb.MovePosition(playerRb.position + playerMovement * playerStats.speed * Time.fixedDeltaTime);
    }

    // Dealing Damage System
    public void DamagePlayer(int damage)
    {
        playerStats.currentHealth -= damage;

        // Updating HelthBar when player taking damage
        healthBar.SetHealth(playerStats.currentHealth);
        if (playerStats.currentHealth <= 0)
        {
            GameManager.KillPlayer(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.DamageEnemy(playerStats.strength);
        }
    }
}
