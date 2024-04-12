using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float xDir;
    private float yDir;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        if (speed == 0)
        {
            speed = 0.02f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Get values
        if (Input.GetKey(KeyCode.W))
        {
            yDir = speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            yDir = -speed;
        }
        else
        {
            yDir = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            xDir = speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            xDir = -speed;
        }
        else
        {
            xDir = 0;
        }

        //Apply values
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + xDir, gameObject.transform.position.y + yDir, gameObject.transform.position.z);
    }
}
