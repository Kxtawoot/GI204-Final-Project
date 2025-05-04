using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 5;
    public float speed = 20f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject); // ชนกับสิ่งอื่นก็หาย
        }
    }
}
