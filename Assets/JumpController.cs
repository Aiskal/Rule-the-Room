using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float raycastDistance = .95f;
    private Color rayColor = Color.red;    
    private LayerMask solLayer;
    [SerializeField] private int jumpPower;    
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        Debug.DrawRay(rayOrigin, Vector3.down * raycastDistance, rayColor);

        Debug.Log("jumpaxis: " + Input.GetAxis("Jump"));
        Debug.Log("jumpbutton: " + Input.GetButtonDown("Jump")); 

        if (Input.GetAxis("Jump")>0 && isGrounded) 
        {
            Debug.Log("Jump");            
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
        Debug.Log("grounded" + isGrounded);
        
    }
}

