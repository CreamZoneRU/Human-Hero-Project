using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Private Components
    [SerializeField] Rigidbody2D playerRb;

    // Public Components
    public HealthBar healthBar;

    // Private Variables
    [SerializeField] float playerSpeed = 7f;

    // Public Variables
    public int playerMaxHealth = 10;
    public int playerCurrentHealth;
    Vector2 playerMovement;

    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        healthBar.SetMaxHealth(playerMaxHealth);
    }


    // Update is called once per frame
    void Update()
    {
        // Captures the horizontal and vertical input
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");

        // Taking Damage Testing
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
    }

    void FixedUpdate()
    {
        // Moves the character to the specified point by pressing the control buttons
        playerRb.MovePosition(playerRb.position + playerMovement * playerSpeed * Time.fixedDeltaTime);
    }

    // Dealing Damage System
    void TakeDamage(int damage)
    {
        playerCurrentHealth -= damage;

        // Updating HelthBar when player taking damage
        healthBar.SetHealth(playerCurrentHealth);
    }
}
