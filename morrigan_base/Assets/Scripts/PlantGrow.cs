using UnityEngine;

public class PlantGrow : MonoBehaviour
{

    Animator animator;
    public bool isPlantGrown = false;
    public bool isPlayer = false;
    public Collider2D player;
    public Inventory inv;
    public Collider2D plant;
    public GameObject CoinPlant;

    void Start()
    {
        animator = GetComponent<Animator>();
        plant = GetComponent<Collider2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
        inv = GameObject.FindWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
        CheckPlayer();
        if (!isPlantGrown && isPlayer && inv.beans > 0 && Input.GetKeyDown(KeyCode.E)) { animator.SetBool("plant", true); isPlantGrown = true; inv.beans -= 1; }
    }

    void CheckPlayer()
    { isPlayer = Physics2D.IsTouching(plant, player); }

    void GiveCoins() // вкл в анимации *PlantGrow через event
    {
        for (int i = 0; i < Random.Range(1, 5); i++)
        {
            Vector3 pos = new Vector3(Random.Range(-1f, 1f), Random.Range(1f, 2f), 0);
            Instantiate(CoinPlant, gameObject.transform.position + pos, Quaternion.identity);            
        }
    }
}