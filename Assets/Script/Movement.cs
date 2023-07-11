using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Animator playerAnim;
    public Rigidbody rb;

    private void Start()
    {
        //Setting initial player position
        rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(0.98f, 2.565f, 0.23f);
        transform.rotation = new Quaternion(0f, 0f, 0f, 1f);
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Hard coding every possible situation for smooth movement
        if (transform.localEulerAngles.x >= 0 && transform.localEulerAngles.x < 90 && transform.localEulerAngles.y == 0)
        {
            Vector3 movement = new Vector3(moveHorizontal, 0f, -moveVertical) * moveSpeed;
            rb.velocity = movement;
        }

        else if (transform.localEulerAngles.x >= 90 && transform.localEulerAngles.x < 180)
        {
            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f) * moveSpeed;
            rb.velocity = movement;
        }

        else if (transform.localEulerAngles.x >= 270 && transform.localEulerAngles.x < 360)
        {
            Vector3 movement = new Vector3(moveHorizontal, -moveVertical, 0f) * moveSpeed;
            rb.velocity = movement;
        }
        else
        {
            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed;
            rb.velocity = movement;
        }

        if(transform.localEulerAngles.z == 90)
        {
            Vector3 movement = new Vector3(0f, moveHorizontal, -moveVertical) * moveSpeed;
            rb.velocity = movement;
        }
        else if(transform.localEulerAngles.z == 180)
        {
            Vector3 movement = new Vector3(-moveHorizontal, 0f, -moveVertical) * moveSpeed;
            rb.velocity = movement;
        }
        else if(transform.localEulerAngles.z == 270)
        {
            Vector3 movement = new Vector3(0f, -moveHorizontal, -moveVertical) * moveSpeed;
            rb.velocity = movement;
        }

        //Playing animation based on movement
        if(playerAnim != null)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                playerAnim.SetBool("Run", true);
            }    
        }
    }
}
