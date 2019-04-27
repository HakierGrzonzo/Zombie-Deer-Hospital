using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private Vector3 position;
    private Vector3 playerPos;
    private Vector3 move;
    private GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //construct movement vector
        position = gameObject.GetComponent<Rigidbody>().transform.position;
        playerPos = playerObject.transform.position;
        Debug.Log(playerPos);
        Vector3 move = playerPos - position;
        //normalize
        move = move.normalized*speed;
        gameObject.GetComponent<Rigidbody>().velocity = move;
    }

    public Movement()
    {
        this.speed = gameObject.GetComponent<Mob>().speed;
    }
}
