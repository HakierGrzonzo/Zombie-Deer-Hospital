using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_Module : MonoBehaviour {
    /*
    public GameObject normalBulletPrefab;
    public GameObject waterBulletPrefab;
    public GameObject 

    void Start()
    {
        var Weapons_dict = new Dictionary<string, Weapons_Module.Weapon>()
            {
                {"Knife", new Weapon(GameObject bulletPrefeb, GameObject bulletSource, int damage, int fireRate, int bulletSpeed, float bulletFlightTime, int spread, bool isShotgun, bool isMelee)},
                {"Scythe", new Weapon(GameObject bulletPrefeb, GameObject bulletSource, int damage, int fireRate, int bulletSpeed, float bulletFlightTime, int spread, bool isShotgun, bool isMelee)},
                {"Water_Gun", new Weapon(GameObject bulletPrefeb, GameObject bulletSource, int damage, int fireRate, int bulletSpeed, float bulletFlightTime, int spread, bool isShotgun, bool isMelee)},
                {"Machine_Gun", new Weapon(GameObject bulletPrefeb, GameObject bulletSource, int damage, int fireRate, int bulletSpeed, float bulletFlightTime, int spread, bool isShotgun, bool isMelee)},
                { "Pistol", new Weapon(GameObject bulletPrefeb, GameObject bulletSource, int damage, int fireRate, int bulletSpeed, float bulletFlightTime, int spread, bool isShotgun, bool isMelee)},
                {"Shotgun",new Weapon(GameObject bulletPrefeb, GameObject bulletSource, int damage, int fireRate, int bulletSpeed, float bulletFlightTime, int spread, bool isShotgun, bool isMelee) }
            };
    } */
    public class Weapon
    {
        GameObject bulletPrefeb;
        GameObject bulletSource;
        int damage;
        int fireRate;
        int bulletSpeed;
        float bulletFlightTime;
        int spread;
        bool isShotgun;
        bool isMelee;
        
        
        public Weapon(GameObject bulletPrefeb, GameObject bulletSource, int damage, int fireRate, int bulletSpeed, float bulletFlightTime, int spread, bool isShotgun, bool isMelee)
        {
            this.bulletPrefeb = bulletPrefeb;
            this.bulletSource = bulletSource;
            this.damage = damage;
            this.fireRate = fireRate;
            this.bulletSpeed = bulletSpeed;
            this.bulletFlightTime = bulletFlightTime;
            this.spread = spread;
            this.isShotgun = isShotgun;
            this.isMelee = isMelee;
        }
        
        void Shoot()
        {

            Transform bulletSourceTransform = bulletSource.GetComponent<Transform>();
            GameObject Bullet = Instantiate(bulletPrefeb, bulletSourceTransform.position, bulletSourceTransform.rotation);
            Bullet.GetComponent<Rigidbody>().AddForce(Bullet.transform.right * bulletSpeed);
            GameObject.Destroy(Bullet,bulletFlightTime);
            //Albo moze zadzialac Destroy(Bullet,DeathTime), sprawdzic jak nie zadziala pierwsze

        }

    }
}
