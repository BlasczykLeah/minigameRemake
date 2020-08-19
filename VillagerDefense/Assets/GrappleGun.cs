using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrappleGun : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrapplable;
    public Transform tip, camera, player;
    private float maxDistance = 100f;
    private SpringJoint joint;
    public GameObject targetIndicator, temp;
    private bool freezeIndicator;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }

        ShowIndicator();
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple()
    {
        RaycastHit hit;
        if(Physics.Raycast(camera.position, camera.forward, out hit, maxDistance))
        {
            freezeIndicator = true;

            lr.positionCount = 2;

            //Instantiate(targetIndicator, hit.point, Quaternion.identity);

            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            temp.transform.position = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * 0.3f;
            joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;
        }
    }

    void DrawRope()
    {
        if (!joint) return;

        lr.SetPosition(0, tip.position);
        lr.SetPosition(1, grapplePoint);
    }

    void StopGrapple()
    {
        lr.positionCount = 0;
        freezeIndicator = false;
        Destroy(joint);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }


    // Used to pass the current grapple point to the gun rotation
    public Vector3 GetGrapplingPoint()
    {
        return grapplePoint;
    }

    void ShowIndicator()
    {
        if (!freezeIndicator)
        {
            if (!temp)
            {
                RaycastHit hit;
                if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance))
                {
                    temp = Instantiate(targetIndicator, hit.point, Quaternion.identity);
                }
            }
            else
            {
                RaycastHit hit;
                if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance))
                {
                    temp.SetActive(true);
                    temp.transform.position = hit.point;
                }
                if(!Physics.Raycast(camera.position, camera.forward, out hit, maxDistance))
                {
                    temp.SetActive(false);
                }
            }
        }
    }
}
