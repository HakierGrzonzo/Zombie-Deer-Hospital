using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed=0f;
    private Vector2 position;
    private Vector2 playerPos;
    private Vector2 move;
    private GameObject playerObject;
    public float maxSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        if (speed != 0f)
        {
            speed = gameObject.GetComponent<Mob>().speed;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.GetComponent<Rigidbody2D>().velocity.magnitude > maxSpeed)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity.normalized * maxSpeed;
        }
        //construct movement vector
        position = gameObject.GetComponent<Rigidbody2D>().transform.position;
        playerPos = playerObject.transform.position;
        //Debug.Log(playerPos);
        Vector2 move = playerPos - position;

        move = move.normalized * speed;
        //normalize

       
        Animator animator = gameObject.GetComponent<Animator>();
        if (animator != null)
        { 
            float moveAngle = Mathf.Atan2(gameObject.GetComponent<Rigidbody2D>().velocity.y, gameObject.GetComponent<Rigidbody2D>().velocity.x) * Mathf.Rad2Deg;
            bool IsPositive;
            if (moveAngle > 0) { IsPositive = true; }
            else { IsPositive = false; }
            animator.SetBool("IsPositive", IsPositive);
            animator.SetFloat("moveAngle", moveAngle);
        }


        gameObject.GetComponent<Rigidbody2D>().AddForce(move,ForceMode2D.Force);
    }

    public Movement()
    {
    }
}
