using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float m_speed;
    [SerializeField] float m_jumpPower;
    [SerializeField] private float raycastDistance = .1f;
    //private Color rayColor = Color.red;
    private LayerMask solLayer;
    [SerializeField] Transform m_transform;
    //[SerializeField] SpriteRenderer m_spriteRenderer;
    [SerializeField] Rigidbody2D m_rb;

    private float horizontalInput;
    private bool isGrounded;

    public int PlayerDirection { get; private set; } = 1;

    //List<int> m_list = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        
        m_transform = GetComponent<Transform>();
        //m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_rb = GetComponent<Rigidbody2D>();
        solLayer = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();        
    }
    private void OnEnable()
    {
        MovePlayerButton.OnMove += HandleMove;
        MovePlayerButton.OnStop += StopMove;
        MovePlayerButton.OnJump += HandleJump;
    }
    private void HandleMove(bool isLeft)
    {
        horizontalInput = isLeft ? -1 : 1;
        PlayerDirection = (int)horizontalInput;

        Vector3 currentScale = transform.localScale;

        if (isLeft && currentScale.x > 0) currentScale.x = -Mathf.Abs(currentScale.x);
        else if (!isLeft && currentScale.x < 0) currentScale.x = Mathf.Abs(currentScale.x);

        transform.localScale = currentScale;
    }
    private void HandleJump()
    {
        CheckGround();
        // Vérifiez si le joueur est au sol avant de sauter
        if (isGrounded)
        {
            
            Debug.Log("Le joueur saute !");
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
    private void StopMove()
    {
        horizontalInput = 0; 
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
