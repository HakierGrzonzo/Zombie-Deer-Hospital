﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timePassed = 0;
    public GameObject myPrefab; //creature to spawn
    public float spawnrate = 2; //delay beetween spawns
    public int spawnLimit = -1; //max no. of spawns, -1 for infinite spawns
    private int enemiesSpawned = 0;
    public float maximalDistanceFromPlayer = -1; //How close must player get for spawner to start working
    private Vector3 distance;
    private GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player");
    }

    private float distanceToPlayer() //calculate distance form player
    {
        Vector3 distance = playerObject.transform.position - gameObject.GetComponent<Rigidbody>().transform.position;
        return distance.magnitude;
    }

    private bool canSpawn() //are conditions for spawning satisfied
    {
        if ((spawnLimit > enemiesSpawned || spawnLimit == -1)&&((int) distanceToPlayer() < (int) maximalDistanceFromPlayer)) { return true; }
        else { return false; }
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        Debug.Log(canSpawn());
        Debug.Log(distanceToPlayer());
        if (canSpawn())
        {
            if (timePassed > spawnrate)
            {
                timePassed = 0;
                Instantiate(myPrefab, gameObject.transform.position, Quaternion.identity.normalized);
                enemiesSpawned++;
            }
        }
    }
}