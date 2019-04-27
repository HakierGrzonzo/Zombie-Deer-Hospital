using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    private float LocalFireRate;
    private float LocalSpread;
    private float FireRateCtrl;
    private bool IsShotgun;
    public GameObject BulletSource;
    public Vector3 FirDir;


	// Use this for initialization
	void Start ()
    {
        //FireRateCtrl = 0;

    }
	

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            foreach (Item itchild in gameObject.GetComponentsInChildren<Item>())
            {
                if (itchild.CurrentlyEquipped == true)
                {
                    LocalFireRate = itchild.FireRate;
                    LocalSpread = itchild.Spread;
                    IsShotgun = itchild.IsShotgun;
                }
            }
            if (Time.time> FireRateCtrl + LocalFireRate)
            {
                FirDir = (transform.right * 500);
                GameObject Bullet = Instantiate(BulletSource, transform.position, Quaternion.identity);
                Bullet.GetComponent<Rigidbody>().AddForce(FirDir);                     
                if (IsShotgun)
                {
                    GameObject Bullet2 = Instantiate(BulletSource, transform.position + transform.forward * 10, Quaternion.identity);
                    GameObject Bullet3 = Instantiate(BulletSource, transform.position + transform.forward * 5, Quaternion.identity);
                    GameObject Bullet4 = Instantiate(BulletSource, transform.position + transform.forward * -5, Quaternion.identity);
                    GameObject Bullet5 = Instantiate(BulletSource, transform.position + transform.forward * -10, Quaternion.identity);


                    FirDir = RotateAroundAxis(FirDir, LocalSpread, transform.up);
                    Bullet2.GetComponent<Rigidbody>().AddForce(FirDir);
                    FirDir = RotateAroundAxis(FirDir, LocalSpread, transform.up);
                    Bullet3.GetComponent<Rigidbody>().AddForce(FirDir);
                    FirDir = RotateAroundAxis(FirDir, -3* LocalSpread, transform.up);
                    Bullet4.GetComponent<Rigidbody>().AddForce(FirDir);
                    FirDir = RotateAroundAxis(FirDir, -1* LocalSpread, transform.up);
                    Bullet5.GetComponent<Rigidbody>().AddForce(FirDir);                   
                }
                FireRateCtrl = Time.time;

            }



            
        }
    }
    public static Vector3 RotateAroundAxis(Vector3 v, float a, Vector3 axis)
    {
        var q = Quaternion.AngleAxis(a, axis);
        return q * v;
    }

}
