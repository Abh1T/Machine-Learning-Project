using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Spawner : MonoBehaviour
{
    public int s;
    bool shouldSpawn;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameObject.Find("Player") != null);
    }

    // Update is called once per frame
    void Update()
    {
        s += (int)(System.Math.Ceiling(Time.deltaTime));
        if (s % 600 == 0) shouldSpawn = true;
        if (shouldSpawn)
        {
            Debug.Log("Spawn");
            UnityEngine.Object specialnana = AssetDatabase.LoadAssetAtPath(("Assets/robote.prefab"), typeof(GameObject));
            GameObject obj = Instantiate(specialnana, transform.position, transform.rotation) as GameObject;

            shouldSpawn = false;
        }
    }
}
