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
        public float timer;

        void Shoot()
        {

            Transform bulletSourceTransform = bulletSource.GetComponent<Transform>();
            GameObject Bullet = Instantiate(bulletPrefab, bulletSourceTransform.position, bulletSourceTransform.rotation);
            Bullet.GetComponent<Rigidbody>().AddForce(Bullet.transform.right * bulletSpeed);
            function OnCollisionEnter(){Destroy(Bullet};
            timer += 1.0f * Time.deltaTime;
            if (timer >=5)
            {
                GameObject.Destroy(Bullet);
             }
            //Albo moze zadzialac Destroy(Bullet,DeathTime), sprawdzic jak nie zadziala pierwsze
        }
    }
}
