using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public class Enemy : MonoBehaviour
{
    [Serializable]
    public class EnemyStats 
    {
        public int health;
        public int strength;
    }

    public EnemyStats enemyStats = new EnemyStats();

    public virtual void DamageEnemy(int damage)
    {
        enemyStats.health -= damage;
        if(enemyStats.health <= 0) 
        {
            GameManager.KillEnemy(this);       
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.DamagePlayer(enemyStats.strength);
        }
    }
}
