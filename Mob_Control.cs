using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Mob_Control : MonoBehaviour
{
    private Transform playerTransform;
    private float moveSpeed;
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
        ChangeWeapon();
        ShootWeapon();
    }

    public void ShootWeapon()
    {
        if (Input.GetMouseButtonDown(0) & this.gameObject.GetComponent<Mob>().currentWeapon.CanShoot())
        {
            this.gameObject.GetComponent<Mob>().currentWeapon.Shoot(); //Input.mousePosition, gameObject.GetComponent<Mob>().currentWeapon.bulletSource.GetComponent<Transform>().position
        }
    }

    public void ChangeWeapon()
    {
        var ScrollWheel = Input.GetAxis("Mouse ScrollWheel");
        int currentWeaponIndex = Array.IndexOf(gameObject.GetComponent<Mob>().Inventory, gameObject.GetComponent<Mob>().currentWeapon);
        int InventoryLength = gameObject.GetComponent<Mob>().Inventory.Length;

        if (ScrollWheel > 0f)
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
        else if (ScrollWheel < 0f)
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
        /*
        if (gameObject.GetComponent<Mob>().currentWeapon.name!=null)
        {
            Debug.Log(gameObject.GetComponent<Mob>().currentWeapon.name);
        }
        */

    }

    private void SpriteUpdate()
    {
        Vector2 MoveDir = player.transform.position - gameObject.transform.position;
        float playerRotationAngle = Mathf.Atan2(MoveDir[0],MoveDir[1]) * Mathf.Rad2Deg;


        if (playerRotationAngle      < -45 || playerRotationAngle  > 45) { gameObject.GetComponent<SpriteRenderer>().sprite = L; }
        else if (playerRotationAngle > -135 &&  playerRotationAngle < 135)  { gameObject.GetComponent<SpriteRenderer>().sprite = R;  }
        else if(playerRotationAngle  <  -135 &&  playerRotationAngle > -45) { gameObject.GetComponent<SpriteRenderer>().sprite = U; }
        else if(playerRotationAngle  >   45 &&  playerRotationAngle < 135) { gameObject.GetComponent<SpriteRenderer>().sprite = D;}

    }
}
