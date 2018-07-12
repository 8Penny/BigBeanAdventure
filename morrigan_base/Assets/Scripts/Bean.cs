using UnityEngine;

public class Bean : MonoBehaviour
{

    public bool isPlayer = false;
    public Collider2D player;
    public Inventory inv;
    public Collider2D bean;
    public GameObject BeanObj;

    void Start()
    {
        BeanObj = gameObject;
        bean = GetComponent<Collider2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
        inv = GameObject.FindWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
        CheckPlayer();
        if (isPlayer) { Destroy(BeanObj); inv.beans++; }
    }

    void CheckPlayer()
    { isPlayer = Physics2D.IsTouching(bean, player); }
}
