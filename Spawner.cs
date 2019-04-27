using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timePassed = 0;
    public GameObject myPrefab;
    private float spawnrate = 2;
    // Start is called before the first frame update
    void Start()
    {
       spawnrate =  gameObject.GetComponent<Mob>().spawnrate;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > spawnrate)
        {
            Instantiate(myPrefab, gameObject.transform.position, Quaternion.identity);
            timePassed = 0;
        }
    }
}
