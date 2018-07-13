using UnityEngine;
using System.Linq;

public class MovebleMonster : Monster {

    [SerializeField]
    public Unit player;
    public Collider2D monster, player_c;
    private float speed = 2.0F;
    
    public float lenPath = 2.0F;
    //private SpriteRenderer sprite;
    private Vector3 direction;

    protected override void Awake()
    {
        //sprite = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void Start()
    {
        direction = transform.right;
        monster = GetComponent<Collider2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Unit>();
        player_c = player.GetComponent<Collider2D>();
    }

    protected override void Update()
    {
        Move();
        if (Physics2D.IsTouching(monster, player_c)) { player.ReceiveDamage(); }
    }


    /*protected override void OnTriggerStay2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit.tag == "Player" )
        {

            //Debug.Log(Mathf.Abs(unit.transform.position.x - transform.position.x));
            //Debug.Log(Mathf.Abs(unit.transform.position.y - transform.position.y));
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 1.3F ) unit.ReceiveDamage();
            //else unit.ReceiveDamage();
        }
    }*/

    private void Move()
    {        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5F + transform.right * direction.x * 0.7F, 0.2F);
        Collider2D[] collidersCheckGround = Physics2D.OverlapCircleAll(transform.position + transform.up * -0.5F + transform.right * direction.x * 1.0F, 0.1F);

        if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<PlayerMovement>()) || collidersCheckGround.Length == 0 || collidersCheckGround.All(x => x.tag != "Ground"))  direction *= -1.0F; 
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}
