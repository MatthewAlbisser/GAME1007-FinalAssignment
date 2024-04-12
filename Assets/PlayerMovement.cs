using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float xDir;
    private float yDir;

    private float speed;
    private float boost;
    // Start is called before the first frame update
    void Start()
    {
        if (speed == 0)
        {
            speed = 0.01f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Get values
        if (Input.GetKey(KeyCode.W))
        {
            yDir = speed + boost;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            yDir = -speed - boost;
        }
        else
        {
            yDir = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            xDir = speed + boost;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            xDir = -speed - boost;
        }
        else
        {
            xDir = 0;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            boost = speed;
        }
        else { boost = 0; }



        //Apply values
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + xDir, gameObject.transform.position.y + yDir, gameObject.transform.position.z);
    }
}
