using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour {

    public Inventory inv;
    Text text;

    void Start () {
        inv = GameObject.FindWithTag("Player").GetComponent<Inventory>();
        text = GetComponent<Text>();
    }	

	void Update () {
        text.text = Convert.ToString(inv.coins);
	}
}
