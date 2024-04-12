using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject player;
    public GameObject Bullet;
    public bool inVision;
    public float cooldown = 3;
    private Vector3 BulletDirection = Vector3.zero;
    public bool lineOfSight = false;

    void Update()
    {
        cooldown -= Time.deltaTime;
        player.transform.position = player.GetComponent<Transform>().position;

        if (lineOfSight)
        {
            BulletDirection = (player.transform.position - transform.position).normalized;
            if (cooldown < 0)
            {
                GameObject enemyBulletClone = GameObject.Instantiate(Bullet, transform.position + BulletDirection, Quaternion.identity);
                enemyBulletClone.GetComponent<Rigidbody>().velocity = BulletDirection * 20;
                Destroy(enemyBulletClone, 5f);
                cooldown = 3;
            }
            
        }

        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hitInfo))
        {
            lineOfSight = hitInfo.collider.CompareTag("Player");
            Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
        }

    }
}
