using UnityEngine;

public class SimpleBounce : MonoBehaviour
{
    public float bouncePower = 10f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0); // เคลียร์ความเร็วแนวตั้งก่อน
                rb.AddForce(Vector2.up * bouncePower, ForceMode2D.Impulse);
            }
        }
    }
}
