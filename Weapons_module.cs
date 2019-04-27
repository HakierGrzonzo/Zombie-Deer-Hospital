using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_Module : MonoBehaviour {

    public class Weapon
    {
        GameObject bulletPrefab;
        GameObject bulletSource;
        int damage;
        int fireRate;
        int bulletSpeed;
        float bulletDistance;
        int spread;

        public Weapon(GameObject bulletPrefab, GameObject bulletSource, int damage, int fireRate, int bulletSpeed, float bulletDistance, int spread)
        {
            this.bulletPrefab = bulletPrefab;
            this.bulletSource = bulletSource;
            this.damage = damage;
            this.fireRate = fireRate;
            this.bulletSpeed = bulletSpeed;
            this.bulletDistance = bulletDistance;
            this.spread = spread;
        }

        void Shoot()
        {

            Transform bulletSourceTransform = bulletSource.GetComponent<Transform>();
            GameObject Bullet = Instantiate(bulletPrefab, bulletSourceTransform.position, bulletSourceTransform.rotation);
            Bullet.GetComponent<Rigidbody>().AddForce(Bullet.transform.right * bulletSpeed);
        }
    }
}
