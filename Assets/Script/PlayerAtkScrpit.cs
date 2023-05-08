using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtkScrpit : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f; // กำหนดเวลาในการยิงกระสุนต่อการกดปุ่ม
    private float nextFireTime = 0f; // เก็บเวลาที่ถัดไปสามารถยิงกระสุนได้

    void Update()
    {
        // ตรวจสอบการกดปุ่มโจมตี โดยกำหนดให้ผู้เล่นสามารถยิงได้เมื่อเวลาถึง
        if ((Input.GetButton("Fire1") || Input.touchCount > 0) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate; // กำหนดเวลาสำหรับการยิงต่อไป

            Vector2 direction = Vector2.zero;

            // ตรวจสอบการคลิกที่จอสัมผัสและดึงข้อมูลตำแหน่งของการแตะที่สุด
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                direction = Camera.main.ScreenToWorldPoint(touch.position) - transform.position;
            }
            else // ถ้าไม่ได้ใช้จอสัมผัสก็ใช้ปุ่มคีย์บอร์ด
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                direction = mousePosition - (Vector2)transform.position;
            }

            direction.Normalize(); // ทำให้เวกเตอร์ทิศทางมีค่าเป็น 1

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }
}
