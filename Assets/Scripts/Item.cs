using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int amountOfHeal;
    private Player player;
    private HealthBar healthBar;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
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

    public void HealPlayer(int amountOfHeal)
    {    
        // if current hp > giving heal = heal normal
        if ((player.playerStats.maxHealth - player.playerStats.currentHealth) < amountOfHeal)
            player.playerStats.currentHealth = player.playerStats.maxHealth;
        // if needed hp < giving heal = heal to full health
        else if (player.playerStats.currentHealth < player.playerStats.maxHealth)
            player.playerStats.currentHealth += amountOfHeal;

        // Update health bar
        healthBar.SetHealth(player.playerStats.currentHealth);
    }
}
