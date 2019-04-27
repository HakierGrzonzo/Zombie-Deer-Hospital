using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody self;
    public int speed;
    public Vector3 position;
    public Vector3 playerPos;
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
        position = self.transform.position;
        playerPos = playerObject.transform.position;
        Debug.Log(playerPos);
        Vector3 move = playerPos - position;
        //normalize
        move = move.normalized*speed;
        self.velocity = move;
    }

    public Movement(Rigidbody self, int speed)
    {
        this.self = self;
        this.speed = speed;
    }
}
