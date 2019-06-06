using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //private float speed; //Obselate, moved to mob
    private Vector2 position;
    private Vector2 playerPos;
    private Vector2 move;
    private GameObject playerObject;
    //public float maxSpeed = 1; //Obselate, moved to mob
    private float timePassed = 0;
    private bool runningAway = false;
    private float timeStartedRunning;
    public float timeToRunAway;
    private Mob Self;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        Self = gameObject.GetComponent<Mob>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.GetComponent<Rigidbody2D>().velocity.magnitude > Self.maxSpeed)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity.normalized * Self.maxSpeed;
        }
        //construct movement vector
        position = gameObject.GetComponent<Rigidbody2D>().transform.position;
        playerPos = playerObject.transform.position;
        //Debug.Log(playerPos);
        Vector2 move = playerPos - position;

        move = move.normalized * Self.speed;
        //normalize

        //animation stuff
        Animator animator = gameObject.GetComponent<Animator>();
        if (animator != null)
        { 
            float moveAngle = Mathf.Atan2(gameObject.GetComponent<Rigidbody2D>().velocity.y, gameObject.GetComponent<Rigidbody2D>().velocity.x) * Mathf.Rad2Deg;
            bool IsPositive;
            if (moveAngle > 0) { IsPositive = true; }
            else { IsPositive = false; }
            moveAngle = Mathf.Abs(moveAngle);
            animator.SetBool("IsPositive", IsPositive);
            animator.SetFloat("moveAngle", moveAngle);
        }

        if (runningAway)
        {
            timePassed += Time.deltaTime;
            if (Time.time- timeStartedRunning > timeToRunAway)
            {
                runningAway = false;
            }
            move = Vector2.zero - move;
            Debug.Log("Geting the fuck out");
        }

        gameObject.GetComponent<Rigidbody2D>().AddForce(move,ForceMode2D.Force);
    }

    public void RunAway(float time)
    {
        timeToRunAway = time;
        this.timeStartedRunning = Time.time;
        runningAway = true;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public Movement()
    {
    }
}
