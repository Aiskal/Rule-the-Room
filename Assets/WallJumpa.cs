using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallJumpa : MonoBehaviour
{
    PlayerMovement m_playerMovement;
    private Rigidbody2D m_rb;

    float m_direction;
    Coroutine m_Coroutine;
    private int m_horizontalInput;
    private int m_PlayerDirection;
    private Animator m_animator;
    [SerializeField] float m_jumpPower = 10f;
    private float m_tempHorizontalInput;

    private void OnEnable()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_playerMovement = GetComponent<PlayerMovement>();
        m_animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 7) return;
        
        LockPlayer();

        MovePlayerButton.OnMove += HandleMove;
        MovePlayerButton.OnStop += StopMove;
        MovePlayerButton.OnJump += HandleJump;

        m_direction = m_playerMovement.PlayerDirection;
        //if(m_Coroutine == null)
        //{
        //    m_Coroutine = StartCoroutine(StickCoroutine());
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 7) return;

        UnlockPlayer();

        MovePlayerButton.OnMove -= HandleMove;
        MovePlayerButton.OnStop -= StopMove;
        MovePlayerButton.OnJump -= HandleJump;
    }


   

    void LockPlayer()
    {
        m_rb.constraints = RigidbodyConstraints2D.FreezeAll;
        m_playerMovement.enabled = false;
    }

    void UnlockPlayer()
    {
        m_rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        m_playerMovement.enabled = true;
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
        UnlockPlayer();

        float escapeVelocity = m_direction < 0 ? -0.75f : 0.75f;

        m_rb.velocity = new Vector2(m_rb.velocity.x + 0-escapeVelocity * m_jumpPower, m_jumpPower);
        m_tempHorizontalInput = -m_direction;
        Debug.Log("WALLJUMP");
    }

    private void StopMove()
    {
        m_animator.SetBool("moving", false);
    }

}
