using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour {

    Animator animator;
    public bool OpenChest = false;
    public bool isPlayer = false;
    public Collider2D player;
    public Collider2D chest;
    
	void Start () {
        animator = GetComponent<Animator>();
        chest = GetComponent<Collider2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
	}

	void Update () {
        CheckPlayer();
		if (!OpenChest && isPlayer && Input.GetKeyDown(KeyCode.E)) { animator.SetBool("Open", true); OpenChest = true; print("You've got GOLD!"); }
	}

    void CheckPlayer()
    { isPlayer = Physics2D.IsTouching(chest, player); }
}
