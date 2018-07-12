using UnityEngine;

public class ChestOpen : MonoBehaviour {

    Animator animator;
    public bool OpenChest = false;
    public bool isPlayer = false;
    public Collider2D player;
    public Collider2D chest;
    public GameObject CoinPlant;

    void Start () {
        animator = GetComponent<Animator>();
        chest = GetComponent<Collider2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
	}

	void Update () {
        CheckPlayer();
		if (!OpenChest && isPlayer && Input.GetKeyDown(KeyCode.E)) { animator.SetBool("Open", true); }
	}

    void CheckPlayer()
    { isPlayer = Physics2D.IsTouching(chest, player); }

    void GiveCoins()
    {
        for (int i = 0; i < Random.Range(3, 7); i++)
        {
            Vector3 pos = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(0.5f, 1f), 0);
            Instantiate(CoinPlant, gameObject.transform.position + pos, Quaternion.identity);
        }
    }
}
