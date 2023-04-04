using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 5f;
    public float distanceBetween; 
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;
    public GameObject bulletParent;
    public GameObject bullet;
    private Transform player;


    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);

        if (distance < distanceBetween && distance > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }

        else if (distance <= shootingRange && nextFireTime < Time.time)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            Instantiate(bullet,bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
       
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distanceBetween);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
