using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    bool facingRight = true;
    public float speed = 5f;
    public float jumpForce = 200f;
    public bool isJumping = false;
    public Animator Anim;
    private Rigidbody2D rb2d;
    public bool hasKey = false;
    public int playerHealth = 100;
    public int maxJumpCount = 1;
    private int jumpCount = 0;
    private float moveInput;
    public UIManager uiManager; 
    private int collectedKeys = 0; 
    public int totalKeys = 1; 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();

        
        if (uiManager == null)
        {
            Debug.LogError("ไม่ได้กำหนด UIManager ใน Inspector ของ Player!");
        }

        // อัปเดต UI เริ่มต้น
        if (uiManager != null)
        {
            uiManager.UpdateKeyCounter(collectedKeys, totalKeys);
        }
    }

    void Update()
    {
        PlayerController();

        if (Input.GetButtonDown("Jump") && jumpCount < maxJumpCount)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jumpCount++;
            isJumping = true;
        }
    }

    void PlayerController()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb2d.linearVelocity = new Vector2(moveInput * speed, rb2d.linearVelocity.y);
        Anim.SetBool("Run", moveInput != 0);

        if (moveInput < 0 && facingRight)
        {
            Flipplayer();
        }
        else if (moveInput > 0 && !facingRight)
        {
            Flipplayer();
        }
    }

    void Flipplayer()
    {
        facingRight = !facingRight;
        Vector3 localscale = transform.localScale;
        localscale.x *= -1;
        transform.localScale = localscale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            jumpCount = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            hasKey = true;
            collectedKeys++; // เพิ่มจำนวนกุญแจที่เก็บได้
            Destroy(collision.gameObject);
            Debug.Log("เก็บกุญแจแล้ว!");

            // อัปเดต UI แสดงจำนวนกุญแจ
            if (uiManager != null)
            {
                uiManager.UpdateKeyCounter(collectedKeys, totalKeys);
            }
        }
    }

    public void TakeDamage(int amount)
    {
        playerHealth -= amount;
        if (playerHealth < 0) playerHealth = 0;

        Debug.Log("Player took damage! HP: " + playerHealth);

        if (playerHealth <= 0)
        {
            Debug.Log("Player is dead!");
            SceneManager.LoadScene("Ui_Lose");
        }
    }
}