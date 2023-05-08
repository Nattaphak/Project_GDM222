using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
    public float speed ; 
    public float lifetime ; 
    public int damage ;

    private float timer = 0f;

    void Update()
    {

        transform.position += transform.forward * speed * Time.deltaTime;


        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
           
            collision.gameObject.GetComponent<EnemyTakeDamage>().TakeDamageEnemy(damage);
        }

        else if (collision.gameObject.CompareTag("Boss"))
        {
           
            collision.gameObject.GetComponent<BossTakeDamage>().TakeDamageBoss(damage);
        }

        Destroy(gameObject);
    }
}