using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;
    [SerializeField] private Transform[] movePoints;
    Rigidbody2D rb;
    public int health = 10;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Behaviour();
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Enemy took damage! Remaining HP: " + health);

        if (health <= 0)
        {
            Debug.Log("Enemy defeated!");
            Destroy(gameObject); // ทำลายศัตรูเมื่อ HP หมด
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
}