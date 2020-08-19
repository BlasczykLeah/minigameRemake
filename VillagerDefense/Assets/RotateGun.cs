using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    public GrappleGun grapple;

    private Quaternion desiredRot;
    private float rotSpeed = 5f;

    private void Update()
    {
        if (!grapple.IsGrappling())
        {
            desiredRot = transform.parent.rotation;
        }
        else
        {
            desiredRot = Quaternion.LookRotation(grapple.GetGrapplingPoint() - transform.position);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRot, Time.deltaTime * rotSpeed);
    }
}
