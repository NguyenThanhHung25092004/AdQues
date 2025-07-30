using UnityEngine;

public class SimpleCharacterMove : MonoBehaviour
{

    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayers;
    [Range(0, .3f)][SerializeField] private float movementSmoothing;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private string horizontalInput = "Horizontal";
    [SerializeField] private KeyCode jumpKey = KeyCode.UpArrow;
    [SerializeField] private float fallMultiplier = 4f;
    [SerializeField] private float jumpMultiplier = 4f;
    [SerializeField] private float interactRadius = 0.5f;
    [SerializeField] private float groundRadius = 0.01f;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Transform groundPosition;

    private float horizontalMove;
    private bool canMove = true;
    [HideInInspector]
    public bool jump = false;
    private bool m_facingRight = true;
    private Animator ani;
    private Rigidbody2D rb;
    private Vector3 m_velocity = Vector3.zero;
    
    void Awake()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            horizontalMove = Input.GetAxisRaw(horizontalInput) * runSpeed;
            ani.SetFloat("Speed", Mathf.Abs(horizontalMove));
            if (Input.GetKeyDown(jumpKey) && isGrounded())
            {
                jump = true;
            }
        }

            Collider2D[] hits = Physics2D.OverlapCircleAll(playerPosition.position, interactRadius);
            foreach (var hit in hits)
            {
                QuestionBlock qb = hit.GetComponent<QuestionBlock>();
                if(qb != null && qb.isPlayerInTrigger(gameObject))
                {
                    qb.Interact();
                    break;
                }
            }
    }

    private void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector2(horizontalMove * 10f * Time.fixedDeltaTime, rb.linearVelocityY);
        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref m_velocity, movementSmoothing);

        if (horizontalMove > 0 && !m_facingRight)
        {
            flip();
        }
        else if (horizontalMove < 0 && m_facingRight)
        {
            flip();
        }

        if(jump)
        {
            SoundLibrary.instance.PlaySound("Jump");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }

        if (rb.linearVelocity.y > 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (jumpMultiplier - 1) * Time.fixedDeltaTime;
        }

        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
    }
    public void setMovementEnabled(bool value)
    {
        canMove = value;
        if (!value)
        {
            horizontalMove = 0f;
            rb.linearVelocity = Vector3.zero; 
        }
    }

    public bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundPosition.position, groundRadius, groundLayers);
    }
    private void flip()
    {
        m_facingRight = !m_facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(playerPosition.position, interactRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundPosition.position, groundRadius);
    }
}
