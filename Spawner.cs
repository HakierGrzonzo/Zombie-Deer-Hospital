using System.Collections;
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
    private Vector2 distance;
    private GameObject playerObject;
    // Start is called before the first frame update
    private int x = 0;
    public int swarmSize = 1;
    public bool DestroyOnLimit = true;
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    private float distanceToPlayer() //calculate distance form player
    {
        Vector2 distance = playerObject.transform.position - gameObject.GetComponent<Rigidbody2D>().transform.position;
        return distance.magnitude;
    }

    private bool canSpawn() //are conditions for spawning satisfied
    {
        if ((spawnLimit > enemiesSpawned || spawnLimit == -1)&&( distanceToPlayer() < maximalDistanceFromPlayer)) { return true; }
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
                while (x < swarmSize)
                {
                    GameObject Enemy = Instantiate(myPrefab, gameObject.transform.position, Quaternion.identity.normalized);
                    x++;
                    Enemy.name = myPrefab.name;
                }
                x = 0;
                enemiesSpawned++;
            }
        }
        else if (enemiesSpawned == spawnLimit && DestroyOnLimit)
        {
            Destroy(this.gameObject);
        }
    }
}
