using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class Movement : Agent
{
    private Transform cube;
    private int counter;
    float steps;

    public override void CollectObservations(VectorSensor sensor)
    {
        try
        {
            sensor.AddObservation(transform.localPosition);
            sensor.AddObservation(cube.transform.localPosition);
        }catch(System.Exception e)
        {
            Debug.Log("GG");
        }

    }
    private void Start()
    {
        Debug.Log(GameObject.Find("Player")!=null);
        cube = GameObject.Find("Player").transform;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Destroy(collision.gameObject);
        }
        Debug.Log(counter);
        if (counter > 400)
            SetReward(4f);
        else if (counter > 300)
        {
            SetReward(3f);
        }
        else if (counter > 200)
        {
            SetReward(2f);
        }
        else
        {
            SetReward(1f);
        }
        EndEpisode();
        Debug.Log("Collision");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(counter);
        if (counter > 400)
            SetReward(4f);
        else if (counter > 300)
        {
            SetReward(3f);
        }
        else if (counter > 200)
        {
            SetReward(2f);
        }
        else
        {
            SetReward(1f);
        }
        EndEpisode();
        Debug.Log("Trigger");
    }
    public override void OnEpisodeBegin()
    {
        steps = 0;
        counter = 500;
        cube = GameObject.Find("Player").transform;
        
    }
    public override void OnActionReceived(float[] vectorAction) //all actions sent in
    {
        transform.Translate(new Vector3(vectorAction[0] * 3 * Time.deltaTime, 0, vectorAction[1] * 3 * Time.deltaTime));
        counter--;
        if (counter <= 0)
        {
            SetReward(-4f);
            EndEpisode();
        }
    }

}