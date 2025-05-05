using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;
    [SerializeField] private Transform[] movePoints;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float fireCooldown = 2f;

    private float fireTimer;
    private Rigidbody2D rb;
    public int health = 10;

    private Transform player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Behaviour();
    }

    private void Update()
    {
        fireTimer += Time.deltaTime;

        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance <= detectionRange && fireTimer >= fireCooldown)
            {
                FireAtPlayer();
                fireTimer = 0f;
            }
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Behaviour()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        if (rb.position.x <= movePoints[0].position.x && velocity.x < 0)
        {
            FlipCharacter();
        }

        else if (rb.position.x >= movePoints[1].position.x && velocity.x > 0)
        {
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        velocity *= -1;

        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void FireAtPlayer()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Vector2 direction = (player.position - firePoint.position).normalized;
            bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * 5f; // ความเร็วกระสุน
        }
    }
}
