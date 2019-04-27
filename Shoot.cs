using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_Module : MonoBehaviour {

    public class Weapon
    {


        public GameObject bulletPrefab;
        public GameObject bulletSource;
        public int damage;
        public int fireRate;
        public int bulletSpeed;
        public float bulletDistance;
        public int spread;

        void Shoot()
        {

            Transform bulletSourceTransform = bulletSource.GetComponent<Transform>();
            GameObject Bullet = Instantiate(bulletPrefab, bulletSourceTransform.position, bulletSourceTransform.rotation);
            Bullet.GetComponent<Rigidbody>().AddForce(Bullet.transform.right * bulletSpeed);
        }
    }
}
