using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRb;

    [SerializeField] float playerSpeed = 7f;

    Vector2 playerMovement;


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
        playerRb.MovePosition(playerRb.position + playerMovement * playerSpeed * Time.fixedDeltaTime);
    }
}
