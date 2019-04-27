using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public float FireRate;
    public GameObject BulletSource;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        float timeStart = Time.time;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log(timeStart-Time.time);

            if (timeStart - Time.time> FireRate)
            {
                timeStart = Time.time;
                GameObject Bullet = Instantiate(BulletSource, transform.position, Quaternion.identity);
                Bullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.right);
            }



          
        }
    }
}
