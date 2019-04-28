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
                Weapons_Module.Weapon shotgun = new Weapon(weaponName, 5, 1,bulletSource, normalBulletPrefab, 70, 0.90f, speedMult * 5.5f, 0.9f, 6.5f, true);
                return (shotgun);

            case "water_gun":
                Weapons_Module.Weapon water_gun = new Weapon(weaponName, 1, 1, bulletSource, normalBulletPrefab, 15, 0.75f, speedMult * 5.0f, 1.5f, 0, false);
                return (water_gun);

            case "pistol":
                Weapons_Module.Weapon pistol = new Weapon(weaponName, 0, 1, bulletSource, normalBulletPrefab, 10, 0.75f, speedMult * 7.0f, 1.7f, 0f, false);
                return (pistol);

            case "AK47":
                Weapons_Module.Weapon AK47 = new Weapon(weaponName, 3, 2, bulletSource, normalBulletPrefab, 55, 0.35f, speedMult * 7.0f, 1.7f, 0f, false);
                return (AK47);

            case "revolver":
                Weapons_Module.Weapon revolver = new Weapon(weaponName, 3, 1, bulletSource, normalBulletPrefab, 84, 0.90f, speedMult * 6.0f, 1.4f, 0, false);
                return (revolver);

            case "uzi":
                Weapons_Module.Weapon uzi = new Weapon(weaponName,1 ,1 , bulletSource, normalBulletPrefab, 24, 0.15f, speedMult * 7.0f, 1.4f, 0, false);
                return (uzi);

            case "M40":
                Weapons_Module.Weapon M40 = new Weapon(weaponName,2 ,2 , bulletSource, normalBulletPrefab, 39, 0.25f, speedMult *7.0 , 1.5f, 0, false);
                return (M40);

            case "sniper_rifle":
                Weapons_Module.Weapon sniper_rifle = new Weapon(weaponName,5 ,7 , bulletSource, normalBulletPrefab,76 , 1,25f, speedMult *7.0 , 1.8f, 0, false);
                return (sniper_rifle);

            case "minigun":
                Weapons_Module.Weapon minigun = new Weapon(weaponName, 1, 1, bulletSource, normalBulletPrefab, 45, 0.091f, speedMult *7.0 , 1.7f, 0, false);
                return (minigun);

            case "Rocket_Launcher":
                Weapons_Module.Weapon Rocket_Launcher = new Weapon(weaponName,19 ,1 , bulletSource, normalBulletPrefab, 345, 1.75f, speedMult *3.0 , 1.4f, 0,false);
                return (Rocket_Launcher);

            case "Flame_Thrower":
                Weapons_Module.Weapon = new Weapon(weaponName, 1, 8, bulletSource, normalBulletPrefab, 7, 0.05f, speedMult * 9.0, 1.9f, 0,false);
                return ();

            case "Knife":
                Weapons_Module.Weapon Knife = new Weapon(weaponName, 0, X, bulletSource, normalBulletPrefab, 30, 0.85f, speedMult * 9.0 , 1.30f, 0,false);
                return (Knife);

            case "Katana":
                Weapons_Module.Weapon Katana = new Weapon(weaponName, 3, X, bulletSource, normalBulletPrefab, 64, 0.75f, speedMult * 9.0, 1.5f, 0,false);
                return (Katana);

            case "Axe":
                Weapons_Module.Weapon Axe = new Weapon(weaponName, 4, X, bulletSource, normalBulletPrefab, 98, 1.35f, speedMult * 8.0, 1.5f, 0,false);
                return (Axe);

            case "Scythe":
                Weapons_Module.Weapon Scythe = new Weapon(weaponName, 5, X, bulletSource, normalBulletPrefab, 80, 0.75f, speedMult * 8.0, 1.5f, 0,);
                return (Scythe);

            case "Chainsaw":
                Weapons_Module.Weapon Chainsaw = new Weapon(weaponName, 5, X, bulletSource, normalBulletPrefab, 20, 0.1f, speedMult * 9.0, 1.4f, 0,);
                return (Chainsaw);

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
                GameObject Bullet2 = Instantiate(bulletPrefab, bulletSourceTransform.position + bulletSourceTransform.forward * 10, Quaternion.identity);
                GameObject Bullet3 = Instantiate(bulletPrefab, bulletSourceTransform.position + bulletSourceTransform.forward * 5, Quaternion.identity);
                GameObject Bullet4 = Instantiate(bulletPrefab, bulletSourceTransform.position + bulletSourceTransform.forward * -5, Quaternion.identity);
                GameObject Bullet5 = Instantiate(bulletPrefab, bulletSourceTransform.position + bulletSourceTransform.forward * -10, Quaternion.identity);

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
