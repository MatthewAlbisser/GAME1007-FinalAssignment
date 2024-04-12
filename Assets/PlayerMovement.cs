using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float xDir;
    private float zDir;

    public float speed;
    public float rotationSpeed;
    private float boost;
    private float overallSpeed;
    // Start is called before the first frame update
    void Start()
    {
        if (speed == 0)
        {
            speed = 10f;
        }

        if (rotationSpeed == 0)
        {
            rotationSpeed = 100f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        overallSpeed = speed + boost;

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);
        }

        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0.0f, -rotationSpeed * Time.deltaTime, 0.0f);
        }

        Vector3 velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            velocity -= transform.forward;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            velocity += transform.forward;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            boost = speed / 1.5f;
        }
        else
        {
            boost = 0.0f;
        }

        transform.position += velocity * overallSpeed * Time.deltaTime;
    }
}
