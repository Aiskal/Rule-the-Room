using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float m_speed;
    [SerializeField] float m_jumpPower;
    [SerializeField] private float raycastDistance = .95f;
    //private Color rayColor = Color.red;
    [SerializeField] LayerMask solLayer;
    [SerializeField] Transform m_transform;
    //[SerializeField] SpriteRenderer m_spriteRenderer;
    [SerializeField] Rigidbody2D m_rb;
    [SerializeField] Transform animateBody;

    private float horizontalInput;
    private bool isGrounded;
    bool moving;

    public int PlayerDirection { get; private set; } = 1;

    //List<int> m_list = new List<int>();
    //public Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        
        m_transform = GetComponent<Transform>();
        //m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_rb = GetComponent<Rigidbody2D>();

        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();
        
    }

    private void Start()
    {
        StartCoroutine(Animate());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HandleJump();
        }
    }
    private void OnEnable()
    {
        MovePlayerButton.OnMove += HandleMove;
        MovePlayerButton.OnStop += StopMove;
        MovePlayerButton.OnJump += HandleJump;
    }
    public void SetDirection(bool left)
    {
        horizontalInput = left ? -1 : 1;
        PlayerDirection = (int)horizontalInput;
    }
    public void SetDirection(int dir)
    {
        horizontalInput = dir;
        if(dir != 0) PlayerDirection = (int)horizontalInput;
    }
    private void HandleMove(bool isLeft)
    {
        SetDirection(isLeft);

        Vector3 currentScale = transform.localScale;
        if (isLeft && currentScale.x > 0) currentScale.x = -Mathf.Abs(currentScale.x);
        else if (!isLeft && currentScale.x < 0) currentScale.x = Mathf.Abs(currentScale.x);
        transform.localScale = currentScale;

        //animator.SetBool("moving", true);
        moving = true;
    }
    private void HandleJump()
    {
        CheckGround();
        // Vérifiez si le joueur est au sol avant de sauter
        if (isGrounded)
        {
            m_rb.velocity = new Vector2(m_rb.velocity.x, m_jumpPower);  // Applique une impulsion verticale
        }
    }
    private void CheckGround()
    {
        // Raycast vers le bas pour vérifier si le joueur touche le sol
        Vector3 rayOrigin = transform.position;
        isGrounded = Physics2D.Raycast(rayOrigin, Vector3.down, raycastDistance, solLayer);
        //Debug.DrawRay(m_transform.position, Vector2.down * 0.1f, Color.red);        
    }
    public void StopMove()
    {
        horizontalInput = 0;

        //animator.SetBool("moving", false);
        moving = false;
    }

    
    IEnumerator Animate()
    {

        Quaternion zero = Quaternion.Euler(0f, 0f, 0f);
        Quaternion left = Quaternion.Euler(0f, 0f, -4f);
        Quaternion right = Quaternion.Euler(0f, 0f, 4f);
        while (true)
        {
            while (moving)
            {
                float elapsedTime = 0;
                while(elapsedTime < 0.1f)
                {
                    elapsedTime += Time.deltaTime;
                    var progress = elapsedTime / 0.1f;
                    animateBody.rotation = Quaternion.Lerp(zero, left, progress);
                    yield return null;
                }

                elapsedTime = 0;
                while (elapsedTime < 0.2f)
                {
                    elapsedTime += Time.deltaTime;
                    var progress = elapsedTime / 0.2f;
                    animateBody.rotation = Quaternion.Lerp(left, right, progress);
                    yield return null;
                }

                elapsedTime = 0;
                while(elapsedTime < 0.1f)
                {
                    elapsedTime += Time.deltaTime;
                    var progress = elapsedTime / 0.1f;
                    animateBody.rotation = Quaternion.Lerp(right, zero, progress);
                    yield return null;
                }
                animateBody.rotation = zero;
            }
            yield return this;
        }
    }
        
    void movement()
    {
        //horizontalInput = Input.GetAxis("Horizontal");
        Vector3 velocity = new(m_speed * Time.fixedDeltaTime * horizontalInput, 0, 0);
        m_transform.position += velocity;
    }
    private void OnDisable()
    {
        MovePlayerButton.OnMove -= HandleMove;
        MovePlayerButton.OnStop -= StopMove;
        MovePlayerButton.OnJump -= HandleJump;
    }
}
