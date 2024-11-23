using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float horizontalInput, facingOnContact, tempHorizontalInput;
    [SerializeField]private PlayerMovement playerMovement;
    [SerializeField]private int jumpPower;
    private Transform m_transform;
    private float speed = 5;

    bool allowJump = false;
    Coroutine stickCoroutine;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        m_transform = rb2D.transform;
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.layer == 7)
        {
            facingOnContact = horizontalInput==0 ? tempHorizontalInput : horizontalInput;
            allowJump = true;
            if(stickCoroutine == null)
            {
                stickCoroutine = StartCoroutine(StickToWall());
            }
        }

    }

    void LockPlayer()
    {
        rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
        playerMovement.enabled = false;
    }

    void UnlockPlayer()
    {
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerMovement.enabled = true;
    }

    IEnumerator StickToWall()
    {
        LockPlayer();
        bool loop = true;

        
        while (loop)
        {
            yield return null;
            float currentMovement = Input.GetAxis("Horizontal");
            if (facingOnContact < 0 && currentMovement >= 0.5 || facingOnContact > 0 && currentMovement <= -0.5)
            {
                UnlockPlayer();
                loop = false;
            }
            if ((Input.GetAxis("Jump") > 0 || Input.GetKeyDown(KeyCode.Space))&& allowJump)
            {
                allowJump = false;
                UnlockPlayer();
                float escapeVelocity = facingOnContact < 0 ? -0.75f : 0.75f;

                rb2D.velocity = new Vector2(rb2D.velocity.x + -escapeVelocity * jumpPower, jumpPower);
                tempHorizontalInput = -facingOnContact;
                loop = false;
                Debug.Log("WALLJUMP");
            }

        }
        stickCoroutine = null;
    }
    
}
