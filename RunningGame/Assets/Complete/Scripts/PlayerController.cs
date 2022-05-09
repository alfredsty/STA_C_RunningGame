using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour //2단점프 코드 갈기
{

    [SerializeField] float jumpForce = 600f;
    float moveX;
    Rigidbody2D rb;
    Animator ani;

    bool doubleJumpState = false;
    bool isGround = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if(rb.velocity.y == 0)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }

        if (isGround)
            doubleJumpState = true;

        if (isGround && Input.GetMouseButtonDown(0))
        {
            JumpAddForce();
            ani.SetBool("Jump",true);  
        }
        else if (doubleJumpState && Input.GetMouseButtonDown(0))
        {
            JumpAddForce();
            doubleJumpState = false;
            ani.SetBool("Jump",true);
        }

        
        rb.velocity = new Vector2(moveX,rb.velocity.y);
        

    }
    void JumpAddForce()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce);
    }

    

}
