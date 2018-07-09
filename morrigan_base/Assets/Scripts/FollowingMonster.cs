﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingMonster : Monster {

    public GameObject target;
    public Vector2 target_pos;


    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        target_pos = new Vector2(target.transform.position.x, target.transform.position.y + 1f);
        
        transform.position = Vector2.MoveTowards(transform.position, target_pos, 0.03f);

    }
}