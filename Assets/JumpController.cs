using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    private Rigidbody2D m_rb;
    private float raycastDistance = .95f;
    //private Color rayColor = Color.red;    
    private LayerMask solLayer;
    [SerializeField] private int m_jumpPower;    
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        solLayer = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckGround();       
    }
    private void CheckGround()
    {
        Vector3 rayOrigin = transform.position;
        isGrounded = Physics2D.Raycast(rayOrigin, Vector3.down, raycastDistance, solLayer);
        //Debug.DrawRay(rayOrigin, Vector3.down * raycastDistance, rayColor);

        //Debug.Log("jumpaxis: " + Input.GetAxis("Jump"));
        //Debug.Log("jumpbutton: " + Input.GetButtonDown("Jump")); 

        if (Input.GetAxis("Jump")>0 && isGrounded) 
        {
            //Debug.Log("Jump");            
            m_rb.velocity = new Vector2(m_rb.velocity.x, m_jumpPower);
        }
        //Debug.Log("grounded" + isGrounded);
        
    }
}

