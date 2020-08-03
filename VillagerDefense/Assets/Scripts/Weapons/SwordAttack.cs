using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : Attack
{
    public bool swinging = false;
    public GameObject swordAnchor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!swinging)
        {
            if (Input.GetMouseButtonDown(0))
            {
                swordAnchor.GetComponent<SwordScript>().StartSwing(gameObject);
                swinging = true;
            }
        }
    }
}
