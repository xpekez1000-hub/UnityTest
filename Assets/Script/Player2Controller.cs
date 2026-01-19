using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    [Header("Move")]
    public float speed = 3f;
    public float jumpForce = 7f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header("Key")]
    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode rightKey = KeyCode.RightArrow;
    public KeyCode jumpKey = KeyCode.RightShift;
    public KeyCode attackKey = KeyCode.Keypad1;
    public KeyCode strikeKey = KeyCode.F5;
    public KeyCode blockKey = KeyCode.F6;
    public KeyCode hurtKey = KeyCode.F7;
    


    Rigidbody2D rb;
    Animator anim;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        float h = 0;
        if (Input.GetKey(leftKey)) h = -1;
        if (Input.GetKey(rightKey)) h = 1;

        rb.velocity = new Vector2(h * speed, rb.velocity.y);

        if (h > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (h < 0) transform.localScale = new Vector3(-1, 1, 1);

        anim.SetBool("Walking", h != 0);

        
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetTrigger("Jump");
        }

        
        if (Input.GetKeyDown(attackKey))
        {
            anim.SetTrigger("Attack");
        }
        if(Input.GetKeyDown(strikeKey))
        {
            anim.SetTrigger("Strike");
        }
        if (Input.GetKeyDown(blockKey))
        {
            anim.SetTrigger("Block");
        }
        if (Input.GetKeyDown(hurtKey))
        {
            anim.SetTrigger("Hurt");
        }
        
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            0.2f,
            groundLayer
        );

        anim.SetBool("Ground", isGrounded);
    }

    void OnDrawGizmos()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, 0.2f);
    }
}

