using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float sensitivity;

    public bool onGround = true;

    //CharacterController cc;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //cc = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, speed * Input.GetAxis("Vertical") * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.velocity = transform.up * jumpForce;
            onGround = false;
        }
    }

    void FixedUpdate()
    {
        float rotHorizontal = -Input.GetAxis("Mouse X");
        transform.RotateAround(transform.position, -Vector3.up, rotHorizontal * sensitivity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ground layer, trying it out
        if (collision.gameObject.layer == 8) onGround = true;
    }
}
