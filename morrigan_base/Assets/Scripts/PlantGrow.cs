using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrow : MonoBehaviour
{

    Animator animator;
    public bool isPlantGrown = false;
    public bool isPlayer = false;
    public Collider2D player;
    public Collider2D plant;
    public Inventory inv;

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
        if (!isPlantGrown && isPlayer && inv.beans>0 && Input.GetKeyDown(KeyCode.E)) { animator.SetBool("plant", true); isPlantGrown = true; inv.beans -= 1; }
    }

    void CheckPlayer()
    { isPlayer = Physics2D.IsTouching(plant, player); }
}