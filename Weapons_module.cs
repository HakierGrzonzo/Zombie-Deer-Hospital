using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_Module : MonoBehaviour{
    //Load a normalBulletPrefab from (Assets/bulletPrefabs/normalBulletPrefab)
    public static GameObject normalBulletPrefab = Resources.Load<GameObject>("BulletPrefabs/normalBulletPrefab");
    //Load a waterBulletPrefab from (Assets/bulletPrefabs/waterBulletPrefab)
    public static GameObject waterBulletPrefab = Resources.Load<GameObject>("BulletPrefabs/waterBulletPrefab");

    public static Weapon GetWeapon(string weaponName, GameObject bulletSource)
    {
        float speedMult = 40f;
        switch (weaponName)
            //Dodaje dodatkowę bronie
        {
            case "shotgun":
                Weapons_Module.Weapon shotgun = new Weapon(weaponName, 5, 1,bulletSource, normalBulletPrefab, 20, 0.90f, speedMult * 5.5f, 0.9f, 6.5f, true);
                return (shotgun);

            case "water_gun":
                Weapons_Module.Weapon water_gun = new Weapon(weaponName, 1, 1, bulletSource, normalBulletPrefab, 15, 0.30f, speedMult * 5.0f, 1.5f, 0, false);
                return (water_gun);

            case "pistol":
                Weapons_Module.Weapon pistol = new Weapon(weaponName, 2, 1, bulletSource, normalBulletPrefab, 10, 0.75f, speedMult * 7.0f, 1.7f, 0f, false);
                return (pistol);

            case "machine_gun":
                Weapons_Module.Weapon machine_Gun = new Weapon(weaponName, 1, 1, bulletSource, normalBulletPrefab, 10, 0.75f, speedMult * 7.0f, 1.7f, 0f, false);
                return (machine_Gun);

        }
        return null;
    }

    public class Weapon
    {
        public string name;
        private int penetration;
        GameObject bulletPrefab;
        private int selfDamage;
        public GameObject bulletSource;
        int damage;
        public float fireRate;
        float bulletSpeed;
        float bulletFlightTime;
        float spread;
        public bool isShotgun;
        private float lastShotTime = Time.time;

        public Weapon(string name, int selfDamage, int penetration, GameObject bulletSource, GameObject bulletPrefab, int damage, float fireRate, float bulletSpeed, float bulletFlightTime, float spread, bool isShotgun)
        {
            this.name = name;
            this.penetration = penetration;
            this.selfDamage = selfDamage;
            this.bulletSource = bulletSource;
            this.bulletPrefab = bulletPrefab;
            this.damage = damage;
            this.fireRate = fireRate;
            this.bulletSpeed = bulletSpeed;
            this.bulletFlightTime = bulletFlightTime;
            this.spread = spread;
            this.isShotgun = isShotgun;
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

        public void Shoot(Mob selfDamageReceiver)
        {
            selfDamageReceiver.hit_received(selfDamage);
            lastShotTime = Time.time;

            Transform bulletSourceTransform = bulletSource.GetComponent<Transform>();
            GameObject Bullet = Instantiate(bulletPrefab, bulletSourceTransform.position, bulletSourceTransform.rotation);
            Bullet.GetComponent<bulletScript>().bulletDamage = damage;
            Bullet.GetComponent<bulletScript>().bulletPenetration = penetration;
            Bullet.GetComponent<bulletScript>().owner = bulletSource.GetComponentInParent<Mob>();
            Bullet.GetComponent<Rigidbody2D>().AddForce(Bullet.transform.up * bulletSpeed);
            GameObject.Destroy(Bullet, bulletFlightTime);
          
            if (isShotgun)
            {               
                GameObject Bullet2 = Instantiate(bulletPrefab, bulletSourceTransform.position, bulletSourceTransform.rotation);
                GameObject Bullet3 = Instantiate(bulletPrefab, bulletSourceTransform.position, bulletSourceTransform.rotation);
                GameObject Bullet4 = Instantiate(bulletPrefab, bulletSourceTransform.position, bulletSourceTransform.rotation);
                GameObject Bullet5 = Instantiate(bulletPrefab, bulletSourceTransform.position, bulletSourceTransform.rotation);

                Vector2 FirDir = ((Input.mousePosition)-bulletSourceTransform.position);

                FirDir = RotateAroundAxis(FirDir, spread, bulletSourceTransform.up);
                Bullet2.GetComponent<Rigidbody>().AddForce(FirDir);
                FirDir = RotateAroundAxis(FirDir, spread, bulletSourceTransform.up);
                Bullet3.GetComponent<Rigidbody>().AddForce(FirDir);
                FirDir = RotateAroundAxis(FirDir, -3 * spread, bulletSourceTransform.up);
                Bullet4.GetComponent<Rigidbody>().AddForce(FirDir);
                FirDir = RotateAroundAxis(FirDir, -1 * spread, bulletSourceTransform.up);
                Bullet5.GetComponent<Rigidbody>().AddForce(FirDir);
            }           
        }
    }
    public static Vector3 RotateAroundAxis(Vector3 v, float a, Vector3 axis)
    {
        var q = Quaternion.AngleAxis(a, axis);
        return q * v;
    } 
}
