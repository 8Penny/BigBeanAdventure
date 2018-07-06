using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public bool isPlayer = false;
    public Collider2D player;
    public Inventory inv;
    public Collider2D coin;
    public GameObject CoinObj;

    void Start()
    {
        CoinObj = gameObject;
        coin = GetComponent<Collider2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
        inv = GameObject.FindWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
        CheckPlayer();
        if (isPlayer) { Destroy(CoinObj); print("You've got 1 Coin!"); inv.coins++; }
    }

    void CheckPlayer()
    { isPlayer = Physics2D.IsTouching(coin, player); }

}
