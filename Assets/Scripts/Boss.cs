using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    SpriteRenderer spriteRenderer;
    Transform bossTransform;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        bossTransform = GetComponent<Transform>();
    }

    public override void DamageEnemy(int damage)
    {
        enemyStats.health -= damage;
        if (enemyStats.health <= 20)
        {
            enemyStats.strength *= 2;
            bossTransform.localScale = Vector3.one * 3;
            spriteRenderer.color = Color.HSVToRGB(0, 96, 49);
        }

        if(enemyStats.health <= 0) 
        {
            GameManager.KillEnemy(this);
            FindObjectOfType<GameManager>().CompleteGame();
        }
    }
}
