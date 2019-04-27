﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_Module : MonoBehaviour {
    public static GameObject normalBulletPrefab;
    public static GameObject waterBulletPrefab;

    public static Weapon GetWeapon(string weaponName)
    {
        var Weapons_dict = new Dictionary<string, Weapon>()
            {
                //{"Knife", new Weapon(GameObject bulletPrefeb, GameObject bulletSource, int damage, int fireRate, int bulletSpeed, float bulletFlightTime, int spread, bool false, bool true)},
                //{"Scythe", new Weapon(GameObject bulletPrefeb, GameObject bulletSource, int damage, int fireRate, int bulletSpeed, float bulletFlightTime, int spread, bool false, bool true)},
                {"Water_Gun", new Weapon(normalBulletPrefab, 15,  0.30f,  5.0f,  1.5f,  0,  false,  false)},
                {"Machine_Gun", new Weapon(normalBulletPrefab, 25,  0.15f,  7.0f,  2.0f ,  0,  false,  false)},
                {"Pistol", new Weapon(normalBulletPrefab, 10 ,  0.75f,  7.0f,  1.7f,  0f,  false,  false)},
                {"Shotgun",new Weapon(normalBulletPrefab, 20,  0.90f,  5.5f,  0.9f,  6.5f,  true, false) }
            };
        return Weapons_dict[weaponName];
    }



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


        public Weapon(GameObject bulletPrefeb, int damage, float fireRate, float bulletSpeed, float bulletFlightTime, float spread, bool isShotgun, bool isMelee)
        {
            this.bulletPrefeb = bulletPrefeb;
            this.damage = damage;
            this.fireRate = fireRate;
            this.bulletSpeed = bulletSpeed;
            this.bulletFlightTime = bulletFlightTime;
            this.spread = spread;
            this.isShotgun = isShotgun;
            this.isMelee = isMelee;
        }

        

        public void Shoot()
        {

            Transform bulletSourceTransform = bulletSource.GetComponent<Transform>();
            GameObject Bullet = Instantiate(bulletPrefeb, bulletSourceTransform.position, bulletSourceTransform.rotation);
            Bullet.GetComponent<Rigidbody>().AddForce(Bullet.transform.right * bulletSpeed);
            GameObject.Destroy(Bullet,bulletFlightTime);
        }
    }
}
