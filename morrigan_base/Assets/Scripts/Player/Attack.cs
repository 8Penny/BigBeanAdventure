using UnityEngine;
using System.Linq;

public class Attack : Unit {

    public CapsuleCollider2D playerCC;
    public Animator animator;

    public bool attack;

    public bool timerOn = false;
    public float timeLeft = 0;

    void Start () {
        playerCC = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

	void Update () {
        if (Input.GetButtonDown("Fire1") && !attack)
        { attack = true; Fight(); }
        if (timerOn) { Fight(); }
    }

    private void FixedUpdate()
    {
        attack = false;
    }

    void Fight()
    {
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(LayerMask.GetMask("Enemy"));

        int numColliders = 10;
        Collider2D[] colliders = new Collider2D[numColliders];
        playerCC.OverlapCollider(contactFilter, colliders);

        timeLeft -= Time.deltaTime;
        if (!timerOn) { timerOn = true; timeLeft = .3f; animator.SetTrigger("Fight"); }
        if (timerOn && timeLeft <= 0) { timerOn = false; Debug.Log("!!!"); }

        if (colliders[0] != null) { if (colliders.Any(x => x.GetComponent<Monster>())) { Monster monster; monster = colliders[0].GetComponent<Monster>(); monster.ReceiveDamage(); } }

        attack = false;
    }
}
