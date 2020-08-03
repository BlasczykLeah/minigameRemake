using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowShoot : Attack
{
    public GameObject Bow;
    public GameObject arrowPref;
    public Transform arrowSpawnpoint;
    public bool inDraw = false;
    public bool hasShot = false;

    //List<GameObject> activeArrows;  // needed? maybe object pool
    GameObject activeArrow;

    // Start is called before the first frame update
    void Start()
    {
        //activeArrow = Instantiate(arrowPref, arrowSpawnpoint.position, Quaternion.Euler(new Vector3(0, 90 + transform.rotation.y, 90)));
        //activeArrow.transform.SetParent(arrowSpawnpoint);
        //activeArrow.transform.localPosition = new Vector3(-0.15F, 0.04F, 0F);
        //activeArrow.transform.localRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        if (!inDraw)
        {
            // check for input, if true set inDraw = true
            // if imediately let go, just reset
            if (Input.GetMouseButtonDown(0)) StartDraw();
        }
        else
        {
            if (!hasShot)
            {
                // check for release, when released reset
                if (Input.GetMouseButtonUp(0)) ShootArrow();
            }
        }
    }

    void StartDraw()
    {
        if (Input.GetMouseButtonUp(0)) return;

        inDraw = true;

        // object pool?
        activeArrow = Instantiate(arrowPref, arrowSpawnpoint.position, Quaternion.identity);
        activeArrow.transform.SetParent(arrowSpawnpoint);
        activeArrow.transform.localPosition = new Vector3(-0.15F, 0.04F, 0F);
        activeArrow.transform.localRotation = Quaternion.identity;

        Bow.GetComponent<Animator>().SetBool("Shooting", true);
        Bow.GetComponent<Animator>().SetTrigger("Draw");
    }

    void ShootArrow()
    {
        hasShot = true;
        activeArrow.GetComponent<ArrowCollider>().Shoot();

        Bow.GetComponent<Animator>().SetBool("Shooting", false);
        // push the arrow forward, remove parent
        // stop the arrow from counting and use that number as the force, also change gravity

        ResetBow();
    }

    void ResetBow()
    {
        inDraw = hasShot = false;
    }
}


/*
 * Needs to:
 * spawn arrow, set parent
 * play animation
 * while holding, arrow will gain more speed (travel faster)
 * whenever input is let go, shoot arrow
 * unset parent, turn on collider
 * reset animation
 * cooldown?
 */