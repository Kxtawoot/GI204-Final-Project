using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;

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
}