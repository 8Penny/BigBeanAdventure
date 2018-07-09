using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour {

    public PlayerMovement mov;
    RectTransform rect;

	void Start () {
        mov = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        rect = GetComponent<RectTransform>();
    }
	

	void Update () {
        if (mov.lives == 3) rect.sizeDelta = new Vector2(300f, 90f);
        else if (mov.lives == 2) rect.sizeDelta = new Vector2(200f, 90f);
        else if (mov.lives == 1) rect.sizeDelta = new Vector2(100f, 90f);
        else rect.sizeDelta = new Vector2(0f, 90f);        
	}
}
