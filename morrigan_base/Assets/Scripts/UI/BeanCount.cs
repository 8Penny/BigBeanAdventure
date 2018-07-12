using System;
using UnityEngine;
using UnityEngine.UI;

public class BeanCount : MonoBehaviour
{

    public Inventory inv;
    Text text;

    void Start()
    {
        inv = GameObject.FindWithTag("Player").GetComponent<Inventory>();
        text = GetComponent<Text>();
    }
    
    void Update()
    {
        text.text = Convert.ToString(inv.beans);
    }
}