using UnityEngine;

public class Player : MonoBehaviour
{
    float moveX;
    bool facingRight = true;
    public float speed = 5f;
    public float jumpForce = 200f;
    public bool isJumping = false;
    public Animator Anim;
    private float moveInput;
    private Rigidbody2D rb2d;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }// Start
    
    void Update()
    {
        PlayerController();
        moveInput = Input.GetAxis("Horizontal");

        // เคลื่อนที่ซ้าย-ขวา
        rb2d.linearVelocity = new Vector2(moveInput * speed, rb2d.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, jumpForce));

        }//Jump

    }// Update

      void PlayerController()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        rb2d.linearVelocity = new Vector2(moveX * speed, rb2d.linearVelocity.y);
        Anim.SetBool("Run", moveX != 0);

        if (moveX < 0 && facingRight)
        {
            Flipplayer();
        }
        else if (moveX > 0 && !facingRight)
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

}

