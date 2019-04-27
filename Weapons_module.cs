using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_Module : MonoBehaviour {
    //Load a normalBulletPrefab from (Assets/bulletPrefabs/normalBulletPrefab)
    public static GameObject normalBulletPrefab = Resources.Load<GameObject>("BulletPrefabs/normalBulletPrefab");
    //Load a waterBulletPrefab from (Assets/bulletPrefabs/waterBulletPrefab)
    public static GameObject waterBulletPrefab = Resources.Load<GameObject>("BulletPrefabs/waterBulletPrefab");

    


    public class Weapon
    {
        GameObject bulletPrefeb;
        public GameObject bulletSource;
        int damage;
        public float fireRate;
        float bulletSpeed;
        float bulletFlightTime;
        float spread;
        bool isShotgun;
        bool isMelee;
        private float lastShotTime = Time.time;


        public Weapon(GameObject bulletSource, GameObject bulletPrefeb, int damage, float fireRate, float bulletSpeed, float bulletFlightTime, float spread, bool isShotgun, bool isMelee)
        {
            this.bulletSource = bulletSource;
            this.bulletPrefeb = bulletPrefeb;
            this.damage = damage;
            this.fireRate = fireRate;
            this.bulletSpeed = bulletSpeed;
            this.bulletFlightTime = bulletFlightTime;
            this.spread = spread;
            this.isShotgun = isShotgun;
            this.isMelee = isMelee;
        }

        public bool CanShoot()
        {
            if (Time.time - lastShotTime > fireRate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Shoot()
        {
            lastShotTime = Time.time;
            Transform bulletSourceTransform = bulletSource.GetComponent<Transform>();
            GameObject Bullet = Instantiate(bulletPrefeb, bulletSourceTransform.position, bulletSourceTransform.rotation);
            Bullet.GetComponent<Rigidbody>().AddForce(Bullet.transform.right * bulletSpeed);
            GameObject.Destroy(Bullet, bulletFlightTime);

            /*
            if (isShotgun)
            {
                GameObject Bullet2 = Instantiate(bulletPrefeb, bulletSourceTransform.position + bulletSourceTransform.forward * 10, Quaternion.identity);
                GameObject Bullet3 = Instantiate(bulletPrefeb, bulletSourceTransform.position + bulletSourceTransform.forward * 5, Quaternion.identity);
                GameObject Bullet4 = Instantiate(bulletPrefeb, bulletSourceTransform.position + bulletSourceTransform.forward * -5, Quaternion.identity);
                GameObject Bullet5 = Instantiate(bulletPrefeb, bulletSourceTransform.position + bulletSourceTransform.forward * -10, Quaternion.identity);

                FirDir = (bulletSourceTransform.right * 500);

                FirDir = RotateAroundAxis(FirDir, LocalSpread, bulletSourceTransform.up);
                Bullet2.GetComponent<Rigidbody>().AddForce(FirDir);
                FirDir = RotateAroundAxis(FirDir, LocalSpread, bulletSourceTransform.up);
                Bullet3.GetComponent<Rigidbody>().AddForce(FirDir);
                FirDir = RotateAroundAxis(FirDir, -3 * LocalSpread, bulletSourceTransform.up);
                Bullet4.GetComponent<Rigidbody>().AddForce(FirDir);
                FirDir = RotateAroundAxis(FirDir, -1 * LocalSpread, bulletSourceTransform.up);
                Bullet5.GetComponent<Rigidbody>().AddForce(FirDir);
            }
            */
        }
    }
}
