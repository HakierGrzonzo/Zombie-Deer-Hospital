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
    public float maxSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        speed = gameObject.GetComponent<Mob>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > maxSpeed)
        {
            gameObject.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Rigidbody>().velocity.normalized * maxSpeed;
        }
        //construct movement vector
        position = gameObject.GetComponent<Rigidbody>().transform.position;
        playerPos = playerObject.transform.position;
        //Debug.Log(playerPos);
        Vector3 move = playerPos - position;

        move = move.normalized * speed;
        move.y = 0;
        //normalize

        gameObject.GetComponent<Rigidbody>().AddForce(move,ForceMode.VelocityChange);
    }

    public Movement()
    {
    }
}
