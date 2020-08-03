using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float sensitiv;
    Vector3 offset;

    float mouseY = 0;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.transform.position + offset;
    }

    void FixedUpdate()
    {
        float rotVertical = -Input.GetAxis("Mouse Y");
        mouseY += rotVertical;

        if(mouseY > -25 && mouseY < 25)
            transform.RotateAround(transform.position, transform.right, rotVertical * sensitiv);
        else
        {
            if (mouseY < -25) mouseY = -25;
            if(mouseY > 25) mouseY = 25;
        }
    }
}
