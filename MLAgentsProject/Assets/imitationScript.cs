using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class imitationScript : Agent
{
    public Transform cube;
    private int counter = -100;
    float steps;

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(cube.transform.localPosition);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered?");
        if (other.gameObject.name.Equals("Cube"))
        {
            
                SetReward(4f);
            EndEpisode();
            
        }else if (other.gameObject.name.Equals("checkpoint"))
        {
            SetReward(1.3f);
            Debug.Log("First Stage");
        }
        else
        {
            Debug.Log(other.name);
            SetReward(-1f);
            
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided?");
        if (collision.gameObject.name.Equals("Cube"))
        {

            SetReward(4f);
            EndEpisode();

        }
        else if (collision.gameObject.name.Equals("checkpoint"))
        {
            SetReward(1.3f);
            Debug.Log("First Stage");
        }
        else
        {
            Debug.Log(collision.gameObject.name);
            SetReward(-1f);    
        }
        
    }
    public override void OnActionReceived(float[] vectorAction) //all actions sent in
    {
        transform.Translate(new Vector3(vectorAction[0] * 6 * Time.deltaTime, 0, vectorAction[1] * 6 * Time.deltaTime));
        counter--;
        if (counter <= 0)
        {
            SetReward(-4f);
            EndEpisode();

        }
        Collider[] col = Physics.OverlapBox(transform.position, Vector3.one * 0.5f);
        foreach (Collider c in col)
        {
            if (c.gameObject.name.Equals("player"))
            {
                SetReward(4f);
            }
        }

    }

    public override void OnEpisodeBegin()
    {
        if (counter == -100)
        {
            Debug.Log("Free hit");
            cube.transform.localPosition = new Vector3(1.5f, 0.55f, 0.09f);
        }
        steps = 0;
        counter = 1200;
        transform.localPosition = new Vector3(16.1f, -1.17f, -13.83f);
        cube.transform.localPosition = new Vector3(2.16f, 0.55f, -3.94f);
    }

    public override void Heuristic(float[] actionsOut)
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -22f, 22f), transform.position.y, Mathf.Clamp(transform.position.z, -22f, 22f));

        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(0f, -4f, 0f, Space.Self);
        }
        if (Input.GetKey(KeyCode.X))
        {
            transform.Rotate(0f, 4f, 0f, Space.Self);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 20);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * 20);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * Time.deltaTime * 20);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 20);
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -22f, 22f), transform.position.y, Mathf.Clamp(transform.position.z, -22f, 22f));

    }
}
