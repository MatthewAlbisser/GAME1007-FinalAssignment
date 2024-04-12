using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject player;
    public bool inVision;
    public float cooldown = 3;
    private Vector3 BulletDirection = Vector3.zero;
    private bool lineOfSight = false;

    void Update()
    {
        player.transform.position = player.GetComponent<Transform>().position;

        if (lineOfSight && inVision)
        {
            BulletDirection = (player.transform.position - transform.position).normalized;
        }

        RaycastHit2D ray = Physics2D.Raycast(Vector2.zero, Vector2.zero);
        ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
    }
}