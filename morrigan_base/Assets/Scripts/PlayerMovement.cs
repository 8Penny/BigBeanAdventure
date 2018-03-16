using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D player;
    SpriteRenderer playerSP;
    Animator animator;

    private bool JumpRequest;
    
    public float horSpeed = 0.1f;
    float speedX;
    public float verImp = 6f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public LayerMask groundLayer;
    private bool attack;


    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerSP = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded()) // вкл прыжок
            { JumpRequest = true;  }
        if (Input.GetButtonDown("Fire1"))
            { attack = true; Fight(); }
    }



    void FixedUpdate()
    {
        if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") < 0 )
        { speedX = -horSpeed; playerSP.flipX = true; animator.SetBool("Move", true); } // задаём направление движения и
        else if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") > 0 )
        { speedX = horSpeed; playerSP.flipX = false; animator.SetBool("Move", true); } // направление взгляда и вкл анимацию бега
        else { animator.SetBool("Move", false); }
        player.transform.Translate(speedX, 0, 0); // движение
        speedX = 0; // обнуляем скорость движения, когда его не должно быть

        if (JumpRequest) // выполнение прыжка
        {
            player.AddForce(new Vector2(0, verImp), ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            JumpRequest = false;
        }

        if (player.velocity.y > 0 && !Input.GetButton("Jump")) // задаём силу прыжка от времени нажатия кнопки прыжка
        { player.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime; }
        else if (player.velocity.y < 0) {
            player.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            animator.SetBool("Fall", true); // при падении вкл анимацию падения
        }
        else if (player.velocity.y >= 0) { animator.SetBool("Fall", false); }

        attack = false;
    }

    bool IsGrounded()// на земле?
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer.value)) { return true; }
        else { animator.ResetTrigger("Jump"); return false; }
    }

    void Fight()
    {
        if (attack)
        { animator.SetTrigger("Fight"); }

    }
}
