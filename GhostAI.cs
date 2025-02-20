using UnityEngine;

public class GhostAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 3.5f;
    public float scatterSpeed = 4f;
    public Transform player;
    public PlayerLightController playerLightController;

    private int currentPoint = 0;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>(); // Get Rigidbody2D component
    }

    void Update()
    {
        if (playerLightController == null || player == null) return;

        if (playerLightController.IsLightOn())  
        {
            Scatter();
        }
        else
        {
            ChasePlayer();
        }
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        Transform target = patrolPoints[currentPoint];
        MoveTowards(target.position, patrolSpeed);

        if (Vector2.Distance(transform.position, target.position) < 0.5f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
    }

    void ChasePlayer()
    {
        MoveTowards(player.position, chaseSpeed);
    }

    void Scatter()
    {
        Vector2 scatterDirection = (transform.position - player.position).normalized;
        MoveTowards((Vector2)transform.position + scatterDirection * 5, scatterSpeed);
    }

    void MoveTowards(Vector2 target, float moveSpeed)
    {
        Vector2 moveDirection = (target - (Vector2)transform.position).normalized;
        rb.linearVelocity = moveDirection * moveSpeed;  // Apply velocity for movement

        spriteRenderer.flipX = moveDirection.x < 0;
    }
}
