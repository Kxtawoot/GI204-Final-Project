using UnityEngine;

public class GhostBullet : MonoBehaviour
{
    public int damage = 20;
    public float speed = 5f;
    public float lifetime = 10f;
    private Transform target;

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            target = playerObj.transform;
        }

        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        if (target != null)
        {
            // เคลื่อนที่เข้าหา Player
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if (!collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
