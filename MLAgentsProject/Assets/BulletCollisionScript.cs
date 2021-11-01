using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (transform.position.x > 30 || transform.position.x < -30 || transform.position.z > 30 || transform.position.z < -30)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("robot") || collision.gameObject.name.Contains("turret")) {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}