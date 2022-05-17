using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour //2단점프 코드 갈기
{

    private Rigidbody2D rigid;
    private Animator anim;
    private SpriteRenderer rend;
    private BoxCollider2D boxColl;
    float collOffset, collSize;

    private AudioSource audioSource;
    public AudioClip jumpAudio, slideAudio, collAudio;

    public int jumpCount = 0;

    enum Sound
    {
        Jump, Slide, Coll
    };

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        boxColl = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        audioSource = this.gameObject.AddComponent<AudioSource>();

        collOffset = boxColl.offset.y;
        collSize = boxColl.size.y;
    }

    void Update()
    {
        float hor = Input.GetAxis("Horizontal");

        if (hor != 0)
        {
            anim.SetBool("Run", true);

            if (hor < 0)
                rend.flipX = true;
            else
                rend.flipX = false;
        }
        else
            anim.SetBool("Run", false);

        if (jumpCount == 0)
        {
            if (Input.GetKey(KeyCode.DownArrow))
                Sliding(true);
            else
                Sliding(false);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount < 2)
            {
                Sliding(false);
                rigid.velocity = new Vector2(rigid.velocity.x, 12.0f); //rigid.AddForce(Vector2.up * 500.0f);
                jumpCount++; 
                anim.SetInteger("Jump", jumpCount);


                if (jumpCount == 2)
                    anim.SetTrigger("DoubleJump");
            }
        }
        rigid.velocity = new Vector2(hor * 5.0f, rigid.velocity.y);
    }

  

    void Sliding(bool value)
    {
        if (value)
        {
            if (anim.GetBool("Sliding"))
                return;

            anim.SetBool("Sliding", true);
            boxColl.size = new Vector2(boxColl.size.x, boxColl.size.y / 2);
            boxColl.offset = new Vector2(boxColl.offset.x, boxColl.offset.y - (boxColl.size.y / 2));
        }
        else
        {
            if (!anim.GetBool("Sliding"))
                return;

            anim.SetBool("Sliding", false);
            boxColl.offset = new Vector2(boxColl.offset.x, boxColl.offset.y + (boxColl.size.y / 2));
            boxColl.size = new Vector2(boxColl.size.x, boxColl.size.y * 2);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            Debug.Log("Collision!");
            jumpCount = 0; //???? ?????? ??????
            anim.SetInteger("Jump", jumpCount);
            anim.SetTrigger("Land"); //?????? ???? ??
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Obstacle")
        {
            Debug.Log("Damaged!");
            anim.SetTrigger("Damaged"); //?????? ?????? ????
            rend.color = new Color(1, 1, 1, 0.4f); //?????? ????
            this.gameObject.layer = LayerMask.NameToLayer("IgnoreCollision"); //?????? ????


            Invoke("ResetDefaultLayer", 2);
        }
    }

    void ResetDefaultLayer()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Default");
        rend.color = new Color(1, 1, 1, 1f); //?????? ????
    }
}
