using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Mob_Control : MonoBehaviour
{
    private Transform playerTransform;
    private float moveSpeed;
    public bool shootPlayer = false;
    public int shootPlayerDistance = 20;
    public Sprite U;
 
    public Sprite L;
   
    public Sprite D;
   
    public Sprite R;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerTransform = GetComponent<Transform>();
        moveSpeed = this.gameObject.GetComponent<Mob>().speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SpriteUpdate();
        CheckAndShoot();
    }

    private void CheckAndShoot()
    {
        if (shootPlayer)
        {
            if ((distanceToPlayer() <= shootPlayerDistance)& this.gameObject.GetComponent<Mob>().currentWeapon.CanShoot())
            {
                gameObject.GetComponent<Mob>().currentWeapon.Shoot(gameObject.GetComponent<Mob>());
            }
        }
    }

    private float distanceToPlayer() //calculate distance form player
    {
        Vector2 distance = player.transform.position - gameObject.GetComponent<Rigidbody2D>().transform.position;
        return distance.magnitude;
    }

    private void SpriteUpdate()
    {
        /*
        Vector2 MoveDir = player.transform.position - gameObject.transform.position;
        float playerRotationAngle = Mathf.Atan2(MoveDir.y,MoveDir.x) * Mathf.Rad2Deg;


        if (playerRotationAngle      < -45 && playerRotationAngle > -135) { gameObject.GetComponent<SpriteRenderer>().sprite = U; }
        else if (playerRotationAngle      > 45 && playerRotationAngle < 135) { gameObject.GetComponent<SpriteRenderer>().sprite = D; }

        else if (playerRotationAngle      > 135) { gameObject.GetComponent<SpriteRenderer>().sprite = L; }
        else if (playerRotationAngle      < -135) { gameObject.GetComponent<SpriteRenderer>().sprite = L; }


        else if (playerRotationAngle      < 45 && playerRotationAngle > -45) { gameObject.GetComponent<SpriteRenderer>().sprite = R; }


    */
    }
}
