using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    private float LocalFireRate;
    private float FireRateCtrl;
    public GameObject BulletSource;

	// Use this for initialization
	void Start ()
    {
        FireRateCtrl = 0;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {

            if (Time.time> FireRateCtrl + LocalFireRate)
            {
                GameObject Bullet = Instantiate(BulletSource, transform.position, Quaternion.identity);
                Bullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.right);
                Debug.Log(gameObject.transform.up);
                FireRateCtrl = Time.time;
            }




            foreach (Item itchild in gameObject.GetComponentsInChildren<Item>())
            {
                if (itchild.CurrentlyEquipped == true)
                {
                    LocalFireRate = itchild.FireRate;
                }
            }



        }
    }
}
