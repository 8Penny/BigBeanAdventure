using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PlayerMovement : Unit {

    Rigidbody2D player;
    SpriteRenderer playerSP;
    Animator animator;
    BoxCollider2D playerBC;
    CapsuleCollider2D playerCC;
    


    private bool JumpRequest;

    public int lives = 5;
    public float horSpeed = 0.1f;
    float speedX;
    public float verImp = 6f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public LayerMask groundLayer = 9;
    public bool right_direction = true;
    public bool attack;




    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerBC = GetComponent<BoxCollider2D>();
        playerSP = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerCC = GetComponent<CapsuleCollider2D>();
        
        
    }

    void Update()
    {

        if (Input.GetButtonDown("Jump") && IsGrounded()) // вкл прыжок
            { JumpRequest = true;  }
        if (Input.GetButtonDown("Fire1") && !attack)
            { attack = true; Fight(); }

    }



    void FixedUpdate()
    {
        if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") < 0 )
        { speedX = -horSpeed; if (right_direction) { transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1f, 1, 1)); right_direction = false; } animator.SetBool("Move", true);  } // задаём направление движения и
        else if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") > 0 )
        { speedX = horSpeed; if (!right_direction) { transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1f, 1, 1)); right_direction = true; } animator.SetBool("Move", true); } // направление взгляда и вкл анимацию бега
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
        { player.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;  }
        else if (player.velocity.y < 0) {
            player.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            
            animator.SetBool("Fall", true); // при падении вкл анимацию падения
        }
        else if (player.velocity.y >= 0) { animator.SetBool("Fall", false); }

        attack = false;
    }

    bool IsGrounded()// на земле?
    {
        
        if ((Physics2D.Raycast(new Vector2(transform.position.x - playerBC.size.x / 2, transform.position.y), Vector2.down, 0.1f, groundLayer.value)) ||
            (Physics2D.Raycast(new Vector2(transform.position.x + playerBC.size.x / 2, transform.position.y), Vector2.down, 0.1f, groundLayer.value))) { return true; }
        else { animator.ResetTrigger("Jump"); return false; }
    }
    public override void ReceiveDamage()
    {
        lives--;
        Debug.Log("-1");
        if (lives == 0) Die(); 
        
    }
    void Fight()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5F + transform.right * speedX * 1.2F, 1.2F);
        //Debug.Log(colliders.Any(x => x.GetComponent<Monster>()));
        //foreach ( Collider2D col in colliders) { Debug.Log(col.GetComponent<Monster>()); }
        
        animator.SetTrigger("Fight");

        if (colliders.Length > 0 && colliders.Any(x => x.GetComponent<Monster>())) { Debug.Log("Hello"); Monster monster; monster = colliders.Where(x => x.GetComponent<Monster>()).Select(x => x.GetComponent<Monster>()).ToList()[0]; monster.ReceiveDamage(); };
        attack = false;
        /*if (attack)
        {
            Debug.Log("FIGHT");
            hit = Physics2D.Raycast((Vector2)transform.position + Vector2.up * 0.5F, (Vector2)transform.position + Vector2.up * 0.5F + Vector2.right, 1.2f, enemyLayer.value);
            Debug.DrawLine((Vector2)transform.position + Vector2.up * 0.5F, (Vector2)transform.position + Vector2.up * 0.5F + Vector2.right * 1.2f, Color.cyan);
            if (hit.collider != null) { Debug.Log("HELLO"); Monster monster; monster = hit.collider.GetComponent<Monster>(); Debug.Log(monster); monster.ReceiveDamage(); }
            /*Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 1.0F + transform.right * speedX * 1.0F, 0.5F);
            if (colliders.All(x => x.tag == "Enemy"))
            {colliders.f
                var reponse = colliders.Equals(r => r.tag == "Enemy"); }
            animator.SetTrigger("Fight"); }*/

    }
}
