using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAiming : MonoBehaviour
{
    public Camera cam;
    public Transform shootPoint;
    private Vector3 BulletDirection = Vector3.zero;
    public GameObject Bullet;

    void Update()
    {
        Vector3 point = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        // Using some math to calculate the point of intersection between the line going through the camera and the mouse position with the XZ-Plane
        float t = cam.transform.position.y / (cam.transform.position.y - point.y);
        Vector3 finalPoint = new Vector3(t * (point.x - cam.transform.position.x) + cam.transform.position.x, 1, t * (point.z - cam.transform.position.z) + cam.transform.position.z);
        //Rotating the object to that point
        transform.LookAt(finalPoint, Vector3.up);


        BulletDirection = (finalPoint - shootPoint.transform.position).normalized;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bulletClone = GameObject.Instantiate(Bullet, shootPoint.transform.position + BulletDirection, Quaternion.identity);
            bulletClone.GetComponent<Rigidbody>().velocity = BulletDirection * 20;
            Destroy(bulletClone, 5f);
        }
    }
}
