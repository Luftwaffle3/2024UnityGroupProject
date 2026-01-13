using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private float Move;

    public float jump;
    public bool isJumping;

    public Animator animator;

    private Rigidbody2D rb;
    private bool isFacingRight = true;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KnockFromRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(KBCounter <= 0)
        { 
            rb.velocity = new Vector2(speed * Move, rb.velocity.y);
        }
        else
        {
            if(KnockFromRight == true)
            {
                rb.velocity = new Vector2(-KBForce * 2, KBForce);
            }
            if(KnockFromRight == false)
            {
                rb.velocity = new Vector2(KBForce * 2, KBForce);
            }

            KBCounter -= Time.deltaTime;
        }
        
        Move = Input.GetAxis("Horizontal");

        

        animator.SetFloat("Speed", Mathf.Abs(Move));

        if (Move < 0 && isFacingRight)
        {
            Flip();
        }
        else if (Move > 0 && !isFacingRight)
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            if (!animator.GetBool("IsJumping"))
            {
                animator.SetBool("IsJumping", true);
                Debug.Log("jump");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void OnJumpAnimationEvent()
    {
        animator.speed = 0;
        Invoke("ResetAnimationSpeed", 1f); // Reset the animator speed after 1 second
    }

    // Reset the animator speed to 1
    void ResetAnimationSpeed()
    {
        animator.speed = 1;
    }
}
