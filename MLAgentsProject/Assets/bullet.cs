using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+0.15f);
        if(transform.position.z > 40f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Destroy: "+collision.gameObject.name);
        if (collision.gameObject.name.Equals("Player"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }else if (!collision.gameObject.name.Equals("Head") && !collision.gameObject.name.Contains("turret"))
        {

        }
        
        
    }
}
