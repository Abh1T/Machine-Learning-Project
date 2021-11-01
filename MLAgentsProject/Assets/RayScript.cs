using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;
using UnityEditor;

public class RayScript : Agent
{
    public float time;
    public GameObject player;
    private int count = 1200;
    public float multi;
    public bool forward;

    public void Update()
    {
        time += Time.deltaTime;
        Debug.DrawRay(transform.position, transform.forward*10f, Color.blue, 60f);
        //Debug.DrawRay();
    }
    public override void OnEpisodeBegin()
    {
        if (count == -100)
        {
            player.transform.localPosition = new Vector3(0, 0.5f, -1.24f);
            var layerMask = 1 << LayerMask.NameToLayer("Player");
            if (Physics.Raycast(transform.position, transform.forward * 10f, out var hit, 60f, layerMask))
            {
                SetReward(1f);
                Debug.Log("starting hit");
          
              
            }
        }
        else
        {
            count = 1200;
          //  transform.localPosition = new Vector3(Random.Range(-4f, 4f), 0.5f, -1.4f);
           // player.transform.localPosition = new Vector3(Random.Range(-2f, 2f), 0.5f, 3.47f);
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        //Debug.Log("CollectObservations");


        try
        {
            sensor.AddObservation(transform.localRotation);
            sensor.AddObservation(transform.localPosition); //position of turret
                                                            //Debug.Log("Turret Transform: " + transform.localPosition);


            sensor.AddObservation(player.transform.localPosition); //position of player
                                                                   //Debug.Log("Player Transform: " + player.transform.localPosition);

            // sensor.AddObservation(transform.position.x - player.transform.position.x);
            //  Debug.Log("X difference: " + (transform.position.x - player.transform.position.x));

            // Debug.Log("CollectObservations End");
        }catch(System.Exception e)
        {
            Debug.Log("gg");
                
        }
    }


    public override void OnActionReceived(float[] vectorAction)
    {
        Debug.Log(vectorAction[0]);
        //count++;
        //Debug.Log(vectorAction.Length);
        //      int i = 0;
        //foreach (float f in vectorAction)
        // {
        //   Debug.Log("Float " + i + ": " + f);
        // i++;
        //        }

        var layerMask = 1 << LayerMask.NameToLayer("Player");
        var direction = transform.forward;
        bool isHit = true;


        if (Physics.Raycast(transform.position, direction*10f, out var hit, 60f, layerMask))
        {
            Debug.Log("Name: "+hit.collider.gameObject.name+", "+ hit.collider.gameObject.name.Equals("Player"));
            if (hit.collider.gameObject.name.Equals("Player"))
            {
                SetReward(1f);
                Debug.Log("hits the cube");
                isHit = false;
                shot();
            }
            EndEpisode();
        }

        if (isHit)
        {
            SetReward(-0.1f);
            Debug.Log("miss");
        }



        transform.Rotate(0, vectorAction[0]*multi, 0);
        count--;
        if (count <= 0)
        {
            SetReward(-4f);
            EndEpisode();
        }

    }

    private void shot()
    {
        if (time % 3 < 0.2) { 
            Object bullet = AssetDatabase.LoadAssetAtPath(("Assets/Bullet.prefab"), typeof(GameObject));
            GameObject bull = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
            bull.transform.Rotate(90, 0, 0);
        }
    }
 



}



