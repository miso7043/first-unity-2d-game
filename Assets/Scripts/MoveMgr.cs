using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveMgr : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded = false;

    [Header("Movement Settings")]
    public float jumpForce = 7f;   // 점프 힘
    public float moveSpeed = 5f;   // 이동 속도

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void StartJump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f); // 기존 Y속도 초기화
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    public void MoveLeft()
    {
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 바닥에 닿았는지 확인
        foreach (var contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f) // 위쪽에서 충돌했을 때만
            {
                isGrounded = true;
                break;
            }
        }
    }
}
