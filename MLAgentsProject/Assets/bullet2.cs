using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (transform.position.z > 40f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Destroy: " + other.gameObject.name);
        if (!other.gameObject.name.Equals("Player"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Destroy: " + collision.gameObject.name);
        if (!collision.gameObject.name.Equals("Player"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
        

    }
}
