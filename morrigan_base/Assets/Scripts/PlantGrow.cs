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

    void Start()
    {
        animator = GetComponent<Animator>();
        plant = GetComponent<Collider2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
    }

    void Update()
    {
        CheckPlayer();
        if (!isPlantGrown && isPlayer && Input.GetKeyDown(KeyCode.E)) { animator.SetBool("plant", true); isPlantGrown = true; print("You've got GOLD!"); }
    }

    void CheckPlayer()
    { isPlayer = Physics2D.IsTouching(plant, player); }

}