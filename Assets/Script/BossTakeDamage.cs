using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossTakeDamage : MonoBehaviour
{
    public int maxHealth ; 
    private int currentHealth; 
    void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamageBoss(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
    }
}
