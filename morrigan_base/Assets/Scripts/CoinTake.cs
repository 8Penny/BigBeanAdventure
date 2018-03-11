using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTake : MonoBehaviour {

    public bool isPlayer = false;
    public Collider2D player;
    public Collider2D coin;
    public GameObject Coin;

    void Start()
    {
        Coin = gameObject;
        coin = GetComponent<Collider2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
    }

    void Update()
    {
        CheckPlayer();
        if (isPlayer) { Destroy(Coin); print("You've got 1 Coin!"); }
    }

    void CheckPlayer()
    { isPlayer = Physics2D.IsTouching(coin, player); }

}
