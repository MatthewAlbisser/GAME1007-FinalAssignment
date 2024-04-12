using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadScript : MonoBehaviour
{
    public GameObject Tread;
    public float lifeTime;
    void Start()
    {
        if (lifeTime == 0)
        {
            lifeTime = 0.5f;
        }
    }
    void FixedUpdate()
    {
        GameObject TreadClone = Instantiate(Tread, gameObject.transform.position, Quaternion.Euler(gameObject.transform.eulerAngles.x,gameObject.transform.eulerAngles.y,gameObject.transform.eulerAngles.z));
        Destroy(TreadClone, lifeTime);
    }
}
