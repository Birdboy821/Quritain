using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoverment : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float jumpSpeed;
    private Rigidbody playerRb;
    public float VerticalInput;
    public float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        VerticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKey("w"))
        {
            playerRb.AddRelativeForce(Vector3.forward * speed * VerticalInput);
        }
        else if (Input.GetKey("s"))
        {
            playerRb.AddRelativeForce(Vector3.forward * speed * VerticalInput);
        }
        else if (Input.GetKey("a"))
        {
            playerRb.AddRelativeForce(Vector3.right * speed * horizontalInput);
        }
        else if (Input.GetKey("d"))
        {
            playerRb.AddRelativeForce(Vector3.right * speed * horizontalInput);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }
}
