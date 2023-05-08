using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTakeDamage : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public RestartButton gameOverMenu;

    public HealthBar healthbar;


    // Start is called before the first frame update
    public void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            gameOverMenu.gameOver();
        }
        healthbar.SetHealth(currentHealth);
    }
}
