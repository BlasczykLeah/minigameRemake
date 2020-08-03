using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    GameObject mySword;
    GameObject myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        mySword = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSwing(GameObject player)
    {
        if (myPlayer == null) myPlayer = player;

        mySword.GetComponent<Collider>().enabled = true;
        mySword.GetComponent<SwordCollider>().enabled = true;
        GetComponent<Animator>().SetTrigger("Swing");
    }

    public void ResetSwing()
    {
        myPlayer.GetComponent<SwordAttack>().swinging = false;
        mySword.GetComponent<SwordCollider>().enabled = false;
        mySword.GetComponent<Collider>().enabled = false;
    }
}

/* 
 turns on/off collider
 resets bool in PlayerAttack
 checks collisions when swinging (maybe turns on script on sword object?)
*/