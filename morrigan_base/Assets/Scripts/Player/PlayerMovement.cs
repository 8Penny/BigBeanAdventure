using UnityEngine;

public class PlayerMovement : Unit {

    Rigidbody2D player;
    BoxCollider2D playerBC;
    Animator animator;

    public int lives = 3;

    public float horSpeed = 0.1f;
    float speedX;
    public float Vy = 0f;
    public bool right_direction = true;

    private bool JumpRequest;
    public float verImp = 6f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public LayerMask groundLayer = 9;

    bool timerOn = false; // таймер активен
    float timeLeft = 2f; // счёт неуязвимости 

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerBC = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded()) { JumpRequest = true; }
        if (timerOn) { timeLeft -= Time.deltaTime; if (timeLeft < 0) { timerOn = false; } }

        Vy = player.velocity.y; // вертикальная скорость для аниматора
        animator.SetFloat("Vy", Vy);

        IsGrounded(); // на земле?
    }

    public override void ReceiveDamage() // Получение урона и уменьшение жизней
    {
        if (!timerOn)
        {
            lives--;
            timeLeft = 2f;
            timerOn = true;
        }
        if (lives == 0) Die();
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") < 0 )
        { speedX = -horSpeed; if (right_direction) { transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1f, 1, 1)); right_direction = false; } animator.SetBool("Move", true);  }
        else if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") > 0 )
        { speedX = horSpeed; if (!right_direction) { transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1f, 1, 1)); right_direction = true; } animator.SetBool("Move", true); }
        else { animator.SetBool("Move", false); }
        player.transform.Translate(speedX, 0, 0); // движение
        
        speedX = 0; // обнуляем скорость движения, когда его не должно быть

        if (JumpRequest) // выполнение прыжка
        {
            player.AddForce(new Vector2(0, verImp), ForceMode2D.Impulse);
            JumpRequest = false;
        }

        if (player.velocity.y > 0 && !Input.GetButton("Jump")) // задаём силу прыжка от времени нажатия кнопки прыжка
        { player.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;  }
        else if (player.velocity.y < 0) {
            player.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    bool IsGrounded()
    {        
        if ((Physics2D.Raycast(new Vector2(transform.position.x - playerBC.size.x / 2, transform.position.y), Vector2.down, 0.1f, groundLayer.value)) ||
            (Physics2D.Raycast(new Vector2(transform.position.x + playerBC.size.x / 2, transform.position.y), Vector2.down, 0.1f, groundLayer.value))) { animator.SetBool("Ground", true); return true; }
        else { animator.SetBool("Ground", false); return false; }
    }
}
