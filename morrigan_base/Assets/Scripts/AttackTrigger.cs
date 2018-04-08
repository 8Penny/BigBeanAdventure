using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {
    public Rigidbody2D hitZone;


    void Start()
    {
        hitZone = GetComponent<Rigidbody2D>();

    }
    // Use this for initialization
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger && CompareTag("Enemy") && Input.GetButton("Fire1")) col.gameObject.GetComponent<Unit>().ReceiveDamage() ;
    }
}
