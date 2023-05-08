using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    public static float damageMultiplier = 1.25f;
    public static NextStage instance;
    private static float num = 5f;
    private float enemy = 5f;
    public float enemyCount;  
    public float stageCount = 1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    
    public void EnemyKilled()
    {
        enemyCount--;
        
        if (enemyCount == 0)
        {
            if(stageCount % 3 != 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                enemy = enemy + num;
                enemyCount = enemy;
                stageCount ++;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                stageCount ++;
            }
            
        }
    }
}
