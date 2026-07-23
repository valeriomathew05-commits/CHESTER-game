using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private float speed = 3f;

    [SerializeField] private int startDirection = 1;

    [SerializeField] private bool stayOnLedges = true;

    private int currentDirection;

    private float halfWidth;

    private float halfHeight;

    private Vector2 movement;

    private bool isGrounded;

    // Start is called before the first frame update
    private void Start()
    {
        halfWidth = spriteRenderer.bounds.extents.x;
        halfHeight = spriteRenderer.bounds.extents.y;
        currentDirection = startDirection;
        //spriteRenderer.flipX = startDirection == 1 ? false : true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        movement.x = speed * currentDirection;
        movement.y = rigidbody.velocity.y;
        rigidbody.velocity = movement;
        SetDirection();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        else
        {
            isGrounded = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }

    private void SetDirection()
    {
        if (!isGrounded) return;

        Vector2 rightPos = new Vector2 (transform.position.x + halfWidth, transform.position.y - halfHeight);
        Vector2 leftPos = new Vector2(transform.position.x - halfWidth, transform.position.y - halfHeight);

        int groundLayer = LayerMask.GetMask("Ground");

        if (rigidbody.velocity.x > 0)
        {
            bool hitWallAhead = Physics2D.Raycast(transform.position, Vector2.right, halfWidth + 0.1f, groundLayer);
            bool hasGroundAhead = Physics2D.Raycast(rightPos, Vector2.down, 0.2f, groundLayer);

            if (hitWallAhead || (stayOnLedges && !hasGroundAhead))
        {
                currentDirection *= -1;
                spriteRenderer.flipX = true;
            }

        }

        else if (rigidbody.velocity.x < 0)
        {
            bool hitWallAhead = Physics2D.Raycast(transform.position, Vector2.left, halfWidth + 0.1f, groundLayer);
            bool hasGroundAhead = Physics2D.Raycast(leftPos, Vector2.down, 0.2f, groundLayer);

            if (hitWallAhead || (stayOnLedges && !hasGroundAhead))
            {
                currentDirection *= -1;
                spriteRenderer.flipX = false;
            }

        }

        Debug.DrawRay(rightPos, Vector2.down * 0.2f, Color.red);
        Debug.DrawRay(leftPos, Vector2.down * 0.2f, Color.red);
    }
}
