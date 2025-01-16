using UnityEngine;

public class WallJump : MonoBehaviour
{
    PlayerMovement m_playerMovement;
    private Rigidbody2D m_rb;

    float m_direction;
    Coroutine m_Coroutine;
    private int m_horizontalInput;
    private int m_PlayerDirection;
    private Animator m_animator;
    [SerializeField] float m_jumpPower = 5f;
    private float m_tempHorizontalInput;

    bool active;
    private void OnEnable()
    {
        Debug.Log("Enable");
        m_rb = GetComponent<Rigidbody2D>();
        m_playerMovement = GetComponent<PlayerMovement>();
        m_animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        if (active)
        {
            this.enabled = true;
            MovePlayerButton.OnMove += HandleMove;
            MovePlayerButton.OnStop += StopMove;
            MovePlayerButton.OnJump += HandleJump;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!enabled || collision.gameObject.layer != 7) return;
        active = true;
        Debug.Log("Enter");
        m_direction = m_playerMovement.PlayerDirection;
        LockPlayer();

        MovePlayerButton.OnMove += HandleMove;
        MovePlayerButton.OnStop += StopMove;
        MovePlayerButton.OnJump += HandleJump;

        //if(m_Coroutine == null)
        //{
        //    m_Coroutine = StartCoroutine(StickCoroutine());
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!enabled || collision.gameObject.layer != 7) return;
        active = false;
        UnlockPlayer();

        Debug.Log("Exit");
        MovePlayerButton.OnMove -= HandleMove;
        MovePlayerButton.OnStop -= StopMove;
        MovePlayerButton.OnJump -= HandleJump;
    }




    void LockPlayer()
    {
        m_rb.constraints = RigidbodyConstraints2D.FreezeAll;
        m_rb.velocity = Vector3.zero;
        m_playerMovement.StopMove();
        m_playerMovement.enabled = false;
    }

    void UnlockPlayer()
    {
        m_rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        m_playerMovement.enabled = true;
        //m_playerMovement.HandleMove();
    }



    
    private void HandleMove(bool isLeft)
    {
        UnlockPlayer();
        m_horizontalInput = isLeft ? -1 : 1;
        m_PlayerDirection = (int)m_horizontalInput;

        Vector3 currentScale = transform.localScale;

        if (isLeft && currentScale.x > 0) currentScale.x = -Mathf.Abs(currentScale.x);
        else if (!isLeft && currentScale.x < 0) currentScale.x = Mathf.Abs(currentScale.x);

        transform.localScale = currentScale;

        m_animator.SetBool("moving", true);
    }
    private void HandleJump()
    {
        if (!active) return;
        UnlockPlayer(); 
        m_playerMovement.SetDirection((int)-m_direction);
        m_playerMovement.StopMove();

        // flip sprites
        Vector3 currentScale = transform.localScale;
        if (-m_direction == -1 && currentScale.x > 0) currentScale.x = -Mathf.Abs(currentScale.x);
        else if (-m_direction == 1 && currentScale.x < 0) currentScale.x = Mathf.Abs(currentScale.x);
        transform.localScale = currentScale;



        float escapeVelocity = m_direction < 0 ? -0.4f : 0.4f;

        m_rb.velocity = new Vector2(m_rb.velocity.x + 0-escapeVelocity * m_jumpPower, m_jumpPower/1.5f);
        m_tempHorizontalInput = -m_direction;
        Debug.Log("WALLJUMP");
    }

    public void StopMove()
    {
        m_animator.SetBool("moving", false);
    }

}
