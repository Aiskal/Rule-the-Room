using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float m_speed;
    [SerializeField] Transform m_transform;
    [SerializeField] SpriteRenderer m_spriteRenderer;

    private float horizontalInput;

    //List<int> m_list = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        
        m_transform = GetComponent<Transform>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        
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
    }
    private void HandleMove(bool isLeft)
    {
        horizontalInput = isLeft ? -1 : 1; 
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

    }
}
