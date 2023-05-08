using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    Rigidbody2D rb;

    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 move = new Vector2(x, y);

        Move(move);

        Animate(move);

    }

    void Move(Vector2 move)
    {
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }

    void Animate(Vector2 move)
    {
        animator.SetFloat("Horizontal", move.x);
        animator.SetFloat("Vertical", move.y);
        animator.SetFloat("Speed", move.magnitude);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.gameObject.CompareTag("Wall"))
    {
        // ไม่ให้ตัวละครเดินผ่านกำแพง
        rb.velocity = Vector2.zero;
    }
    }
}
