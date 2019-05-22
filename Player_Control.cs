using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player_Control : MonoBehaviour
{
    private Transform playerTransform;
    private float moveSpeed;
    public GameObject MinimapCamera;
    public int CameraHeight;

    /*
    public Sprite U;
    public Sprite UL;       These are not needed as they are overwritten by animated clips
    public Sprite L;
    public Sprite DL;
    public Sprite D;
    public Sprite DR;
    public Sprite R;
    public Sprite UR;
    */

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        moveSpeed = this.gameObject.GetComponent<Mob>().speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CameraFollowing();
        SpriteUpdate();
        ChangeWeapon();
        ShootWeapon();
    }


    public void ShootWeapon()
    {
        if (Input.GetMouseButton(0) & this.gameObject.GetComponent<Mob>().currentWeapon.CanShoot())
        {
            this.gameObject.GetComponent<Mob>().currentWeapon.Shoot(gameObject.GetComponent<Mob>());
        }
    }

    public void ChangeWeapon()
    {
        var ScrollWheel = Input.GetAxis("Mouse ScrollWheel");
        int currentWeaponIndex = gameObject.GetComponent<Mob>().GetCurrentWeaponIndex();
        int InventoryLength = gameObject.GetComponent<Mob>().Inventory.Length;

        if (ScrollWheel < 0f)
        {
            //scroll up
            if (currentWeaponIndex<InventoryLength-1)
            {
                gameObject.GetComponent<Mob>().currentWeapon = gameObject.GetComponent<Mob>().Inventory[currentWeaponIndex + 1];
            }
            else
            {
                gameObject.GetComponent<Mob>().currentWeapon = gameObject.GetComponent<Mob>().Inventory[0];
            }
        }
        else if (ScrollWheel > 0f)
        {
            // scroll down
            if (currentWeaponIndex > 0)
            {
                gameObject.GetComponent<Mob>().currentWeapon = gameObject.GetComponent<Mob>().Inventory[currentWeaponIndex - 1];
            }
            else
            {
                gameObject.GetComponent<Mob>().currentWeapon = gameObject.GetComponent<Mob>().Inventory[InventoryLength-1];
            }
        }
    }

    private void Move()
    {
        Animator animator = gameObject.GetComponent<Animator>();

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 currentPos = playerTransform.position;
        Vector3 movementVector = new Vector3(horizontal, vertical, 0.0f);

        //float playerRotationAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        //Quaternion playerRotation =Quaternion.Euler(new Vector3(0, 0, playerRotationAngle));

        playerTransform.SetPositionAndRotation(currentPos+ movementVector*moveSpeed, Quaternion.identity);

        if (movementVector.magnitude >0) { animator.SetBool("IsMoving", true); }
        else animator.SetBool("IsMoving", false);
        //MOZNA TO PRZEZ TO DODAC: gameObject.GetComponent<Rigidbody2D>().AddForce()
    }

    private void CameraFollowing()
    {
        Camera.main.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1* CameraHeight);
        MinimapCamera.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -499);
    }
    private void SpriteUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(playerTransform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float playerRotationAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        Animator animator = gameObject.GetComponent<Animator>();

        animator.SetFloat("DirectionFacing", Mathf.Abs(playerRotationAngle));
        bool IsPositive;
        if (playerRotationAngle > 0) { IsPositive = true; }
        else { IsPositive = false; }
        animator.SetBool("IsPositive", IsPositive);
        /*
        if (playerRotationAngle      < -157.5 || playerRotationAngle  > 157.5) { gameObject.GetComponent<SpriteRenderer>().sprite = L; }
        else if (playerRotationAngle > -22.5  &&  playerRotationAngle < 22.5)  { gameObject.GetComponent<SpriteRenderer>().sprite = R;  }
        else if(playerRotationAngle  <  -67.5 &&  playerRotationAngle > -112.5) { gameObject.GetComponent<SpriteRenderer>().sprite = U; }
        else if(playerRotationAngle  >   67.5 &&  playerRotationAngle < 112.5) { gameObject.GetComponent<SpriteRenderer>().sprite = D;}

        else if(playerRotationAngle  >   22.5 &&  playerRotationAngle < 67.5) { gameObject.GetComponent<SpriteRenderer>().sprite = DL;  }
        else if(playerRotationAngle  <   -22.5 &&  playerRotationAngle > -67.5) { gameObject.GetComponent<SpriteRenderer>().sprite = UL; }

        else if(playerRotationAngle  <   157.5  &&  playerRotationAngle > 112.5) { gameObject.GetComponent<SpriteRenderer>().sprite = DR;}
        else if(playerRotationAngle  >   -157.5  &&  playerRotationAngle < -112.5) { gameObject.GetComponent<SpriteRenderer>().sprite = UR;  }
        */

    }
}
