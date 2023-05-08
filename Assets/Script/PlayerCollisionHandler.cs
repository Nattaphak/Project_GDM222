using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            // ถ้าตัวละครชนกับ Wall ให้ย้อนกลับไปที่ตำแหน่งก่อนหน้า
            transform.position = transform.position - (Vector3)collision.relativeVelocity.normalized * 0.1f;
        }
    }
}