using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int amountOfHeal;
    private PlayerController player;
    private HealthBar healthBar;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            HealPlayer(amountOfHeal);
            Destroy(gameObject);
        }
    }

    void HealPlayer(int amountOfHeal)
    {    
        // if current hp > giving heal = heal normal
        if ((player.playerMaxHealth - player.playerCurrentHealth) < amountOfHeal)
            player.playerCurrentHealth = player.playerMaxHealth;
        // if needed hp < giving heal = heal to full health
        else if (player.playerCurrentHealth < player.playerMaxHealth)
            player.playerCurrentHealth += amountOfHeal;

        // Update health bar
        healthBar.SetHealth(player.playerCurrentHealth);
    }
}
