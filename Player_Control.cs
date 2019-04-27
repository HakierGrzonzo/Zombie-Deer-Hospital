using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    private Transform playerTransform;
    private float moveSpeed;
    public int CameraHeight;
    public Sprite U;
    public Sprite UL;
    public Sprite L;
    public Sprite DL;
    public Sprite D;
    public Sprite DR;
    public Sprite R;
    public Sprite UR;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        moveSpeed = this.gameObject.GetComponent<Mob>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Move(vertical, horizontal);
        CameraFollowing();
        SpriteUpdate();
        if (Input.GetMouseButtonDown(0) & this.gameObject.GetComponent<Mob>().currentWeapon.CanShoot())
        {
            this.gameObject.GetComponent<Mob>().currentWeapon.Shoot();
        }
    }

    private void Move(float Vertical, float Horizontal)
    {
        Vector3 currentPos = playerTransform.position;
        Vector3 movementVector = new Vector3(Horizontal,Vertical,0.0f);
        //float playerRotationAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        //Quaternion playerRotation =Quaternion.Euler(new Vector3(0, 0, playerRotationAngle));

        playerTransform.SetPositionAndRotation(currentPos+ movementVector*moveSpeed, Quaternion.identity);
    }

    private void CameraFollowing()
    {
        Camera.main.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1* CameraHeight);
    }
    private void SpriteUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(playerTransform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float playerRotationAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

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
