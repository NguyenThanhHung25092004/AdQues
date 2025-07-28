using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_jumpForce;
    [Range(0, .3f)][SerializeField] private float m_movementSmoothing;
    [SerializeField] private bool m_airControl = false;
    [SerializeField] private LayerMask m_whatIsGround;
    [SerializeField] private Transform m_groundCheck;

    public float k_groundedRadius = .2f;
    private bool m_grounded;
    private Rigidbody2D m_rigidbody2D;
    private bool m_facingRight = true;
    private Vector3 m_velocity = Vector3.zero;

    [Header("Events")]
    [Space]

    public UnityEvent onLandEvent;
    private void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();

        if(onLandEvent == null )
        {
            onLandEvent = new UnityEvent();
        }

    }

    private void FixedUpdate()
    {
        bool wasGrounded = m_grounded;
        m_grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_groundCheck.position, k_groundedRadius, m_whatIsGround);
        for(int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_grounded = true;
                if(!wasGrounded)
                {
                    onLandEvent.Invoke();
                }
            }
        }
    }

    public void Move(float move, bool jump)
    {
        if(m_grounded || m_airControl)
        {
            Vector3 targetVelocity = new Vector2(move * 10f, m_rigidbody2D.linearVelocityY);
            m_rigidbody2D.linearVelocity = Vector3.SmoothDamp(m_rigidbody2D.linearVelocity, targetVelocity, ref m_velocity, m_movementSmoothing);

            if(move > 0 && !m_facingRight)
            {
                flip();
            } else if(move < 0 && m_facingRight)
            {
                flip();
            }

            if(m_grounded && jump)
            {
                m_grounded = false;
                m_rigidbody2D.AddForce(Vector2.up * m_jumpForce, ForceMode2D.Impulse);
            }
        } 
    }

    private void flip()
    {
        m_facingRight = !m_facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
}
