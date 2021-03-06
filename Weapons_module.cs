﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_Module : MonoBehaviour{
    //Load a normalBulletPrefab from (Assets/bulletPrefabs/normalBulletPrefab)
    public static GameObject normalBulletPrefab = Resources.Load<GameObject>("BulletPrefabs/normalBulletPrefab");
    public static GameObject bdeer = Resources.Load<GameObject>("BulletPrefabs/bdeerBulletPrefab");
    public static GameObject brocket = Resources.Load<GameObject>("BulletPrefabs/brocketPrefab");

    public static GameObject bshotgun = Resources.Load<GameObject>("BulletPrefabs/bshotgunBulletPrefab");
    public static GameObject bpistol = Resources.Load<GameObject>("BulletPrefabs/bpistolBulletPrefab");
    public static GameObject bak47 = Resources.Load<GameObject>("BulletPrefabs/bak47BulletPrefab");
    public static GameObject buzi = Resources.Load<GameObject>("BulletPrefabs/buziBulletPrefab");
    public static GameObject bm16 = Resources.Load<GameObject>("BulletPrefabs/bm16BulletPrefab");
    public static GameObject bsniper_rifle = Resources.Load<GameObject>("BulletPrefabs/bsniperBulletPrefab");
    public static GameObject bfire = Resources.Load<GameObject>("BulletPrefabs/bfire");
    public static GameObject bmelee = Resources.Load<GameObject>("BulletPrefabs/bmelee");




    public static GameObject droppedWeaponPrefab = Resources.Load<GameObject>("GunSPrefabs/droppedWeaponPrefab");


    //Loads Weapons Sprites
    public static Sprite pistoletSprite = Resources.Load<Sprite>("GunSPrefabs/pistolet");  //Import all equipable weapons here according to their sprite name
    public static Sprite revolverSprite = Resources.Load<Sprite>("GunSPrefabs/revolver");
    public static Sprite uziSprite = Resources.Load<Sprite>("GunSPrefabs/uzi");
    public static Sprite knifeSprite = Resources.Load<Sprite>("GunSPrefabs/knife");
    public static Sprite katanaSprite = Resources.Load<Sprite>("GunSPrefabs/katana");


    public static Sprite shotgunSprite =  Resources.Load<Sprite>("GunSPrefabs/shotgun");
    public static Sprite ak47Sprite = Resources.Load<Sprite>("GunSPrefabs/ak");
    public static Sprite m16Sprite = Resources.Load<Sprite>("GunSPrefabs/m16");
    public static Sprite nothingSprite = Resources.Load<Sprite>("GunSPrefabs/nothing");

    public static Sprite sniper_rifleSprite = Resources.Load<Sprite>("GunSPrefabs/sniper_rifle");
    public static Sprite minigunSprite = Resources.Load<Sprite>("GunSPrefabs/minigun");
    public static Sprite rocket_launcherSprite = Resources.Load<Sprite>("GunSPrefabs/rocket_launcher");
    public static Sprite flame_throwerSprite = Resources.Load<Sprite>("GunSPrefabs/flame_thrower");
    public static Sprite machine_gunSprite = Resources.Load<Sprite>("GunSPrefabs/machine_gun");
    //public static Sprite korwins_gunSprite = Resources.Load<Sprite>("GunSPrefabs/korwins_gun");



    //Audio effect

    public static AudioClip shotgunSoundEffect = Resources.Load<AudioClip>("SoundEffects/sdShotgun");

    public static AudioClip pistolSoundEffect = Resources.Load<AudioClip>("SoundEffects/sdPistol");

    public static AudioClip ak47SoundEffect = Resources.Load<AudioClip>("SoundEffects/sdAK47");

    public static AudioClip revolverSoundEffect = Resources.Load<AudioClip>("SoundEffects/sdRevolver");

    public static AudioClip uziSoundEffect = Resources.Load<AudioClip>("SoundEffects/sdUzi");

    public static AudioClip m16SoundEffect = Resources.Load<AudioClip>("SoundEffects/sdM16");

    public static AudioClip sniperrifleSoundEffect = Resources.Load<AudioClip>("SoundEffects/sdSniper");

    public static AudioClip minigunSoundEffect = Resources.Load<AudioClip>("SoundEffects/sdMinigun");

    //public static AudioClip rocketlauncherSoundEffect = Resources.Load<GameObject>("SoundEffects/");

    public static AudioClip flamethrowerSoundEffect = Resources.Load<AudioClip>("SoundEffects/sdFlamethrower");

    //public static AudioClip knifeSoundEffect = Resources.Load<GameObject>("SoundEffects/");

    //public static AudioClip katanaSoundEffect = Resources.Load<GameObject>("SoundEffects/");

    //public static AudioClip axeSoundEffect = Resources.Load<GameObject>("SoundEffects/");

    //public static AudioClip scytheSoundEffect = Resources.Load<GameObject>("SoundEffects/");

    //public static AudioClip chainsawSoundEffect = Resources.Load<GameObject>("SoundEffects/");

    public static Sprite GetWeaponSprite(string weaponName)
    {
        switch (weaponName)
        //Dodaje dodatkowę bronie
        {
            case "Shotgun":
                Sprite Shotgun = shotgunSprite;
                return (Shotgun);
            /*
            case "Water_gun":
                Sprite Water_gun = water_gunSprite;
                return (Water_gun);
            */
            case "Pistol":
                Sprite Pistol = pistoletSprite;
                return (Pistol);

            case "AK47":
                Sprite AK47 = ak47Sprite;
                return (AK47);

            case "Revolver":
                Sprite Revolver = revolverSprite;
                return (Revolver);

            case "Uzi":
                Sprite Uzi = uziSprite;
                return (Uzi);

            case "M16":
                Sprite M16 = m16Sprite;
                return (M16);

            case "Knife":
                Sprite Knife = knifeSprite;
                return (Knife);

            case "Katana":
                Sprite Katana = katanaSprite;
                return (Katana);

            case "Nothing1":
                Sprite Nothing1 = nothingSprite;
                return (Nothing1);

            case "Nothing2":
                Sprite Nothing2 = nothingSprite;
                return (Nothing2);

            case "Nothing3":
                Sprite Nothing3 = nothingSprite;
                return (Nothing3);

            case "Sniper_rifle":
                Sprite Sniper_rifle = sniper_rifleSprite;
                return (Sniper_rifle);

            case "Minigun":
                Sprite Minigun = minigunSprite;
                return (Minigun);

            case "Rocket_Launcher":
                Sprite Rocket_Launcher = rocket_launcherSprite;
                return (Rocket_Launcher);

            case "Flame_Thrower":
                Sprite Flame_Thrower = flame_throwerSprite;
                return (Flame_Thrower);

            case "machine_gun":
                Sprite machine_Gun = machine_gunSprite;
                return (machine_Gun);
            
                /*
            case "korwins_gun":
                Sprite korwins_gun = korwins_gunSprite;
                return (korwins_gun);
                */
        }
        return null;
    }

    public static Weapon GetWeapon(string weaponName, GameObject bulletSource)
    {
        float speedMult = 40f;
        switch (weaponName)
            //Dodaje dodatkowę bronie
        {
            case "Shotgun":
                Weapons_Module.Weapon Shotgun = new Weapon(weaponName,2 , 5, 1,bulletSource, bshotgun, 20, 0.90f, speedMult * 9.0f, 0.9f, 6.5f, true, Resources.Load<AudioClip>("SoundEffects/sdShotgun"));
                return (Shotgun);

            case "Rocket_Launcher":
                Weapons_Module.Weapon Rocket_Launcher = new Weapon(weaponName, 3, 20, 5, bulletSource, brocket,300,2,speedMult*9.0f,2.0f,0,false,Resources.Load<AudioClip>("SoundEffects/sdFlamethrower"));
                return (Rocket_Launcher);

            case "Water_gun":
                Weapons_Module.Weapon Water_gun = new Weapon(weaponName,1, 1, 1, bulletSource, normalBulletPrefab, 15, 0.30f, speedMult * 5.0f, 1.5f, 0, false );
                return (Water_gun);

            case "Pistol":
                Weapons_Module.Weapon Pistol = new Weapon(weaponName,1 ,0 ,1 , bulletSource, bpistol, 10, 0.75f, speedMult * 7.0f, 1.7f, 0f, false, Resources.Load<AudioClip>("SoundEffects/sdPistol"));
                return (Pistol);

            case "AK47":
                Weapons_Module.Weapon AK47 = new Weapon(weaponName,2 , 3, 2, bulletSource, bak47, 26, 0.16f, speedMult * 7.0f, 1.7f, 0f, false, Resources.Load<AudioClip>("SoundEffects/sdAK47"));
                return (AK47);

            case "Revolver":
                Weapons_Module.Weapon Revolver = new Weapon(weaponName,1 ,3 ,1 , bulletSource, bshotgun, 84, 0.90f, speedMult * 9.0f, 1.4f, 0, false, Resources.Load<AudioClip>("SoundEffects/sdRevolver"));
                return (Revolver);

            case "Uzi":
                Weapons_Module.Weapon Uzi = new Weapon(weaponName,1 ,1 ,1 , bulletSource, buzi, 24, 0.15f, speedMult * 10.0f, 1.4f, 0, false, Resources.Load<AudioClip>("SoundEffects/sdUzi"));
                return (Uzi);

            case "M16":
                Weapons_Module.Weapon M16 = new Weapon(weaponName,2,2 ,2 , bulletSource, bm16, 39, 0.25f, speedMult *9.0f , 1.5f, 0, false, Resources.Load<AudioClip>("SoundEffects/sdM16"));
                return (M16);

            case "Sniper_rifle":
                Weapons_Module.Weapon Sniper_rifle = new Weapon(weaponName,2 ,5 ,7 , bulletSource, bsniper_rifle,76 , 1.25f, speedMult *11.0f , 1.8f, 0, false, Resources.Load<AudioClip>("SoundEffects/sdSniper"));
                return (Sniper_rifle);

            case "Minigun":
                Weapons_Module.Weapon Minigun = new Weapon(weaponName,3, 1, 1, bulletSource, buzi, 35, 0.091f, speedMult *10.5f , 1.7f, 0, false, Resources.Load<AudioClip>("SoundEffects/sdMinigun"));
                return (Minigun);
            
            case "Flame_Thrower":
                Weapons_Module.Weapon Flame_Thrower  = new Weapon(weaponName,3, 5, 8, bulletSource, bfire, 7, 0.05f, speedMult * 7.5f, 1.9f, 10,true, Resources.Load < AudioClip >("SoundEffects/sdFlamethrower"));
                return (Flame_Thrower);

            case "Katana":
                Weapons_Module.Weapon Katana = new Weapon(weaponName, 1, 2, 7, bulletSource, bmelee, 100, 0.75f, speedMult * 1.75f, 0.3f, 0, false);
                return (Katana);
            
            case "Knife":
                Weapons_Module.Weapon Knife = new Weapon(weaponName,1 ,0 ,4 , bulletSource, normalBulletPrefab, 30, 0.85f, speedMult * 1.75f, 0.3f, 0,false);
                return (Knife);

            case "Axe":
                Weapons_Module.Weapon Axe = new Weapon(weaponName,1 ,4 ,5 , bulletSource, normalBulletPrefab, 98, 1.35f, speedMult * 1.75f, 0.3f, 0,false);
                return (Axe);

            case "Scythe":
                Weapons_Module.Weapon Scythe = new Weapon(weaponName,2, 5, 8, bulletSource, normalBulletPrefab, 80, 0.75f, speedMult * 1.75f, 0.3f, 0,false);
                return (Scythe);
            
            case "Chainsaw":
                Weapons_Module.Weapon Chainsaw = new Weapon(weaponName,1 ,5 ,10 ,bulletSource , normalBulletPrefab, 20, 0.1f, speedMult * 1.75f, 0.3f, 0,false);
                return (Chainsaw);
            
            
            case "Korwins_gun":
                Weapons_Module.Weapon korwins_gun = new Weapon(weaponName,1, 0, 1, bulletSource, bdeer, 100, 0.5f, speedMult * 0f, 100f, 0f, false);
                return (korwins_gun);

            case "Nothing1":
                Weapons_Module.Weapon Nothing1 = new Weapon(weaponName, 1, 0, 0, bulletSource, normalBulletPrefab, 0, 0.0f, 0.0f, 0.0f, 0f, false);
                return (Nothing1);

            case "Nothing2":
                Weapons_Module.Weapon Nothing2 = new Weapon(weaponName, 2, 0, 0, bulletSource, normalBulletPrefab, 0, 0.0f, 0.0f, 0.0f, 0f, false);
                return (Nothing2);

            case "Nothing3":
                Weapons_Module.Weapon Nothing3 = new Weapon(weaponName, 3, 0, 0, bulletSource, normalBulletPrefab, 0, 0.0f, 0.0f, 0.0f, 0f, false);
                return (Nothing3);
        }
        return null;
    }

    public class Weapon
    {
        public string name;
        public int tier;
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
        private AudioSource audioSource;
        private AudioClip sound;

        public Weapon(string name, int tier, int selfDamage, int penetration, GameObject bulletSource, GameObject bulletPrefab, int damage, float fireRate, float bulletSpeed, float bulletFlightTime, float spread, bool isShotgun, AudioClip sound = null)
        {
            this.name = name;
            this.tier = tier;
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
            this.sound = sound;
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
            selfDamageReceiver.DealSelfDamage(selfDamage);
            lastShotTime = Time.time;
            
            audioSource = bulletSource.GetComponent<AudioSource>();
            audioSource.PlayOneShot(sound);
            Transform bulletSourceTransform = bulletSource.GetComponent<Transform>();

            GameObject Bullet = Instantiate(bulletPrefab, bulletSourceTransform.position, bulletSourceTransform.rotation);
            Bullet.GetComponent<bulletScript>().bulletDamage = damage;
            Bullet.GetComponent<bulletScript>().bulletPenetration = penetration;
            Bullet.GetComponent<bulletScript>().owner = bulletSource.GetComponentInParent<Mob>();
            Bullet.GetComponent<Rigidbody2D>().AddForce(Bullet.transform.up * bulletSpeed);

            if (name == "Korwins_gun")
             {
                 Debug.Log("True gun is here!!!");
                 Bullet.GetComponent<bulletScript>().percentDamage = 5;
             }
             
            GameObject.Destroy(Bullet, bulletFlightTime);

            if (isShotgun)
            {
                if (name == "Flame_Thrower") { spread = Random.Range(3, 20); }


                //GameObject Bullet2 = Instantiate(bulletPrefab, bulletSourceTransform.position, bulletSourceTransform.rotation);
                lastShotTime = Time.time;

                Vector2 FirDir = (Bullet.transform.up * bulletSpeed);

                FirDir = RotateAroundAxis(FirDir, spread, bulletSourceTransform.forward);
                bulletSourceTransform = bulletSource.GetComponent<Transform>();
                GameObject Bullet2 = Instantiate(bulletPrefab, bulletSourceTransform.position, new Quaternion(0, 0, Random.Range(0, 360), 1));
                Bullet2.GetComponent<bulletScript>().bulletDamage = damage;
                Bullet2.GetComponent<bulletScript>().bulletPenetration = penetration;
                Bullet2.GetComponent<bulletScript>().owner = bulletSource.GetComponentInParent<Mob>();
                Bullet2.GetComponent<Rigidbody2D>().AddForce(FirDir);
                GameObject.Destroy(Bullet2, bulletFlightTime);

                FirDir = RotateAroundAxis(FirDir, spread, bulletSourceTransform.forward);
                bulletSourceTransform = bulletSource.GetComponent<Transform>();
                GameObject Bullet3 = Instantiate(bulletPrefab, bulletSourceTransform.position, new Quaternion(0, 0, Random.Range(0, 360), 1));
                Bullet3.GetComponent<bulletScript>().bulletDamage = damage;
                Bullet3.GetComponent<bulletScript>().bulletPenetration = penetration;
                Bullet3.GetComponent<bulletScript>().owner = bulletSource.GetComponentInParent<Mob>();
                Bullet3.GetComponent<Rigidbody2D>().AddForce(FirDir);
                GameObject.Destroy(Bullet3, bulletFlightTime);

                FirDir = RotateAroundAxis(FirDir, spread*-3, bulletSourceTransform.forward);
                bulletSourceTransform = bulletSource.GetComponent<Transform>();
                GameObject Bullet4 = Instantiate(bulletPrefab, bulletSourceTransform.position, new Quaternion(0, 0, Random.Range(0, 360), 1));
                Bullet4.GetComponent<bulletScript>().bulletDamage = damage;
                Bullet4.GetComponent<bulletScript>().bulletPenetration = penetration;
                Bullet4.GetComponent<bulletScript>().owner = bulletSource.GetComponentInParent<Mob>();
                Bullet4.GetComponent<Rigidbody2D>().AddForce(FirDir);
                GameObject.Destroy(Bullet4, bulletFlightTime);

                FirDir = RotateAroundAxis(FirDir, spread * -1, bulletSourceTransform.forward);
                bulletSourceTransform = bulletSource.GetComponent<Transform>();
                GameObject Bullet5 = Instantiate(bulletPrefab, bulletSourceTransform.position, new Quaternion(0, 0, Random.Range(0, 360), 1));
                Bullet5.GetComponent<bulletScript>().bulletDamage = damage;
                Bullet5.GetComponent<bulletScript>().bulletPenetration = penetration;
                Bullet5.GetComponent<bulletScript>().owner = bulletSource.GetComponentInParent<Mob>();
                Bullet5.GetComponent<Rigidbody2D>().AddForce(FirDir);
                GameObject.Destroy(Bullet5, bulletFlightTime);
            }
        }
    }
    public static Vector3 RotateAroundAxis(Vector3 v, float a, Vector3 axis)
    {
        var q = Quaternion.AngleAxis(a, axis);
        return q * v;
    }
}
