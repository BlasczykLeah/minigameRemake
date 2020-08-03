using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour
{
    private void Start()
    {
        // needs to be turn-off-able
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("I hit something");
    }*/

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I hit a thing");
    }
}
