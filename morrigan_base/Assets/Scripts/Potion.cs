using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{

    public bool isPlayer = false;
    public Collider2D player;
    public PlayerMovement mov;
    public Collider2D potion;
    public GameObject PotionObj;

    void Start()
    {
        PotionObj = gameObject;
        potion = GetComponent<Collider2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
        mov = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        CheckPlayer();
        if (isPlayer && mov.lives<3) { Destroy(PotionObj); mov.lives++; }
    }

    void CheckPlayer()
    { isPlayer = Physics2D.IsTouching(potion, player); }

}
