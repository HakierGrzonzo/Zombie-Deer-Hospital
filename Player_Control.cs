using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player_Control : MonoBehaviour
{
    private Transform playerTransform;
    //private float moveSpeed;
    public GameObject MinimapCamera;
    public int CameraHeight;
    public GameObject MaximapDisplay;
    public GameObject MaximapMarkers;
    private Mob Self;

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
        Self = gameObject.GetComponent<Mob>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CameraFollowing();
        SpriteUpdate();
        ChangeWeapon();
        ShootWeapon();
        PauseGame();
    }


    public void ShootWeapon()
    {
        if (Input.GetMouseButton(0) & Self.currentWeapon.CanShoot())
        {
            Self.currentWeapon.Shoot(Self);
        }
    }

    public void ChangeWeapon()
    {
        var ScrollWheel = Input.GetAxis("Mouse ScrollWheel");
        int currentWeaponIndex = Self.GetCurrentWeaponIndex();
        int InventoryLength = Self.Inventory.Length;

        if (ScrollWheel < 0f)
        {
            //scroll up
            if (currentWeaponIndex<InventoryLength-1)
            {
                Self.currentWeapon = Self.Inventory[currentWeaponIndex + 1];
            }
            else
            {
                Self.currentWeapon = Self.Inventory[0];
            }
        }
        else if (ScrollWheel > 0f)
        {
            // scroll down
            if (currentWeaponIndex > 0)
            {
                Self.currentWeapon =Self.Inventory[currentWeaponIndex - 1];
            }
            else
            {
                Self.currentWeapon = Self.Inventory[InventoryLength-1];
            }
        }
    }

    private void Move()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        if (Time.timeScale > 0)
        {

            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            Vector3 currentPos = playerTransform.position;
            Vector3 movementVector = new Vector3(horizontal, vertical, 0.0f);

            //float playerRotationAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            //Quaternion playerRotation =Quaternion.Euler(new Vector3(0, 0, playerRotationAngle));

            playerTransform.SetPositionAndRotation(currentPos + movementVector * Self.speed, Quaternion.identity);

            if (movementVector.magnitude > 0) { animator.SetBool("IsMoving", true); }
            else animator.SetBool("IsMoving", false);
        }
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


    public void PauseGame()
    {
        Time.timeScale = 1;
        if (Input.GetKey(KeyCode.Escape)|| Input.GetKey(KeyCode.Backspace) || Input.GetKey(KeyCode.M))
        {
            Time.timeScale = 0.0f;
            MaximapDisplay.SetActive(true);
            MaximapMarkers.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Backspace) || Input.GetKeyUp(KeyCode.M))
        {
            Time.timeScale = 1;
            MaximapDisplay.SetActive(false);
            MaximapMarkers.SetActive(false);
        }




    }
}
