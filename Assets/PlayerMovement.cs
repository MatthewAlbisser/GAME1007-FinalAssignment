using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10f;
    public float rotationSpeed = 100f;
    private float overallSpeed;
    private float boost;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (speed == 0)
        {
            speed = 10f;
        }

        if (rotationSpeed == 0)
        {
            rotationSpeed = 100f;
        }
    }
    void FixedUpdate()
    {
        overallSpeed = speed + boost;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            boost = speed / 1.5f;
        }
        else
        {
            boost = 0;
        }

        // WASD Controls
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        // Forwards and Backwards
        Vector3 movement = new Vector3(0, 0, Vertical);
        rb.velocity = (transform.forward * overallSpeed * Vertical);
        // Body Rotation
        float rotation = Horizontal * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotation);
    }
}

//    // Update is called once per frame
//    void Update()
//    {
//        overallSpeed = speed + boost;

//        if (Input.GetKey(KeyCode.E))
//        {
//            transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);
//        }

//        else if (Input.GetKey(KeyCode.Q))
//        {
//            transform.Rotate(0.0f, -rotationSpeed * Time.deltaTime, 0.0f);
//        }

//        Vector3 velocity = Vector3.zero;
//        if (Input.GetKey(KeyCode.W))
//        {
//            velocity -= transform.forward;
//        }

//        else if (Input.GetKey(KeyCode.S))
//        {
//            velocity += transform.forward;
//        }

//        if (Input.GetKey(KeyCode.LeftShift))
//        {
//            boost = speed / 1.5f;
//        }
//        else
//        {
//            boost = 0.0f;
//        }

//        transform.position += velocity * overallSpeed * Time.deltaTime;
//    }
//}
