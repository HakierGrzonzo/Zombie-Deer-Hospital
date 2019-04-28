using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_Module : MonoBehaviour {
    //Load a normalBulletPrefab from (Assets/bulletPrefabs/normalBulletPrefab)
    public static GameObject normalBulletPrefab = Resources.Load<GameObject>("BulletPrefabs/normalBulletPrefab");
    //Load a waterBulletPrefab from (Assets/bulletPrefabs/waterBulletPrefab)
    public static GameObject waterBulletPrefab = Resources.Load<GameObject>("BulletPrefabs/waterBulletPrefab");

    public static Weapon GetWeapon(string weaponName, GameObject bulletSource)
    {
        float speedMult = 40f;
        switch (weaponName)
        {
            case "shotgun":
                Weapons_Module.Weapon shotgun = new Weapon(weaponName, bulletSource, normalBulletPrefab, 20, 0.90f, speedMult * 5.5f, 0.9f, 6.5f, true, false);
                return (shotgun);

            case "water_gun":
                Weapons_Module.Weapon water_gun = new Weapon(weaponName, bulletSource, normalBulletPrefab, 15, 0.30f, speedMult * 5.0f, 1.5f, 0, false, false);
                return (water_gun);

            case "pistol":
                Weapons_Module.Weapon pistol = new Weapon(weaponName, bulletSource, normalBulletPrefab, 10, 0.75f, speedMult * 7.0f, 1.7f, 0f, false, false);
                return (pistol);

            case "machine_Gun":
                Weapons_Module.Weapon machine_Gun = new Weapon(weaponName, bulletSource, normalBulletPrefab, 10, 0.75f, speedMult * 7.0f, 1.7f, 0f, false, false);
                return (machine_Gun);

        }
        return null;
    }

    public class Weapon
    {
        public string name;
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

        public Weapon(string name, GameObject bulletSource, GameObject bulletPrefeb, int damage, float fireRate, float bulletSpeed, float bulletFlightTime, float spread, bool isShotgun, bool isMelee)
        {
            this.name = name;
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

        public void Shoot(Vector3 mousePos, Vector3 bulletSourcePos)
        {

            mousePos.x = mousePos.x - bulletSourcePos.x;
            mousePos.y = mousePos.y - bulletSourcePos.y;
            float bulletRotation = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

            lastShotTime = Time.time;
            Transform bulletSourceTransform = bulletSource.GetComponent<Transform>();
            GameObject Bullet = Instantiate(bulletPrefeb, bulletSourceTransform.position, new Quaternion(0f, 0f, bulletRotation,1) );
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
