using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollider : MonoBehaviour
{
    public bool counting = true;
    public float myForce = 0;

    bool colliderActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counting)
        {
            myForce += Time.deltaTime * 10.5F;
            if(myForce >= 50F)
            {
                myForce = 50;
                counting = false;
            }
        }
    }

    public void Shoot()
    {
        counting = false;
        if(myForce <= 8F)
        {
            // welp
            Destroy(gameObject);
        }
        else
        {
            //GetComponent<Rigidbody>().AddForce(new Vector3(0, myForce, 0))
            transform.SetParent(null);
            //GetComponent<Rigidbody>().velocity = new Vector3(0, 0, myForce);
            GetComponent<Rigidbody>().velocity = transform.up * myForce;
            //GetComponent<Rigidbody>().AddForce(transform.up * myForce);
            GetComponent<Rigidbody>().isKinematic = false;

            GetComponent<Collider>().enabled = true;
            colliderActive = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (colliderActive)
        {
            // hit a thing, destroy or add to object pool
            Debug.Log("Pew Pew");
        }
    }
}
