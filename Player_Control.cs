using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    private Transform playerTransform;
    private float moveSpeed;
    public int CameraHeight;

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
    }

    private void Move(float Vertical, float Horizontal)
    {
        Vector3 currentPos = playerTransform.position;
        Vector3 movementVector = new Vector3(Horizontal,Vertical,0.0f);
        Debug.Log(movementVector);
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(playerTransform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float playerRotationAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        Quaternion playerRotation =Quaternion.Euler(new Vector3(0, 0, playerRotationAngle));

        playerTransform.SetPositionAndRotation(currentPos+ movementVector*moveSpeed, playerRotation);
    }

    private void CameraFollowing()
    {
        Camera.main.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1* CameraHeight);
    }

}
