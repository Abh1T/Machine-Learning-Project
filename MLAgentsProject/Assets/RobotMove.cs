using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RobotMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {

            transform.Rotate(3,0,0);
        }
        if (Input.GetKey(KeyCode.S))
        {

            transform.Rotate(-3, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 5f, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -5f, 0);
        }
        if (Input.GetKey("right"))
        {
            
            transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
        }
        if (Input.GetKey("left"))
        {
            transform.position = new Vector3(transform.position.x-0.5f, transform.position.y, transform.position.z);
        }
        if (Input.GetKey("up"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+0.5f);
        }
        if (Input.GetKey("down"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z-0.5f);
        }
        if (Input.GetKey("space"))
        {
      //      shoot();
        }
    }
    private void shoot()
    {
        UnityEngine.Object specialnana = AssetDatabase.LoadAssetAtPath(("Assets/Bullet2.prefab"), typeof(GameObject));
        GameObject obj = Instantiate(specialnana, transform.position, transform.rotation) as GameObject;
        obj.transform.Rotate(90, 0, 0);
        obj.GetComponent<Rigidbody>().AddForce(transform.forward*2f, ForceMode.Impulse);

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit by: "+collision.gameObject.name);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered: "+other.gameObject.name);
    }
}
