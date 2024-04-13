using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 velocity;
    private float speed = 5;
    void Start()
    {
        velocity = transform.forward * speed;
    }
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Vector3 normal = collision.contacts[0].normal;
            velocity = Vector3.Reflect(velocity, normal);
        }

        else if (collision.gameObject.GetComponent<Health>() != null)
        {
            collision.gameObject.GetComponent<Health>().health -= 1;
            Destroy(gameObject);
        }
    }
}
