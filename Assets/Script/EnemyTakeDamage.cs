using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    public int maxHealth ; 
    private int currentHealth; 
    void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamageEnemy(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            NextStage.instance.EnemyKilled();
        }
    }
}
