using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_Module : MonoBehaviour{
    //Load a normalBulletPrefab from (Assets/bulletPrefabs/normalBulletPrefab)
    public static GameObject normalBulletPrefab = Resources.Load<GameObject>("BulletPrefabs/normalBulletPrefab");
    //Load a waterBulletPrefab from (Assets/bulletPrefabs/waterBulletPrefab)
    public static GameObject waterBulletPrefab = Resources.Load<GameObject>("BulletPrefabs/waterBulletPrefab");
    public static GameObject rocketBulletPrefab = Resources.Load<GameObject>("BulletPrefabs/rocketBulletPrefab");

    //Audio effect

    public static AudioClip shotgunSoundEffect = Resources.Load<GameObject>("SoundEffects/sdShotgun");

    public static AudioClip pistolSoundEffect = Resources.Load<GameObject>("SoundEffects/sdPistol");

    public static AudioClip ak47SoundEffect = Resources.Load<GameObject>("SoundEffects/sdAK47");

    public static AudioClip revolverSoundEffect = Resources.Load<GameObject>("SoundEffects/sdRevolver");

    public static AudioClip uziSoundEffect = Resources.Load<GameObject>("SoundEffects/sdUzi");

    public static AudioClip m16SoundEffect = Resources.Load<GameObject>("SoundEffects/sdM16");

    public static AudioClip sniperrifleSoundEffect = Resources.Load<GameObject>("SoundEffects/sdSniper");

    public static AudioClip minigunSoundEffect = Resources.Load<GameObject>("SoundEffects/sdMinigun");

    //public static AudioClip rocketlauncherSoundEffect = Resources.Load<GameObject>("SoundEffects/");

    public static AudioClip flamethrowerSoundEffect = Resources.Load<GameObject>("SoundEffects/");

    //public static AudioClip knifeSoundEffect = Resources.Load<GameObject>("SoundEffects/");

    //public static AudioClip katanaSoundEffect = Resources.Load<GameObject>("SoundEffects/");

    //public static AudioClip axeSoundEffect = Resources.Load<GameObject>("SoundEffects/");

    //public static AudioClip scytheSoundEffect = Resources.Load<GameObject>("SoundEffects/");

    //public static AudioClip chainsawSoundEffect = Resources.Load<GameObject>("SoundEffects/");


    public static Weapon GetWeapon(string weaponName, GameObject bulletSource)
    {
        float speedMult = 40f;
        switch (weaponName)
            //Dodaje dodatkowę bronie
        {
            case "Shotgun":
                Weapons_Module.Weapon shotgun = new Weapon(weaponName, 5, 1,bulletSource, normalBulletPrefab, 20, 0.90f, speedMult * 5.5f, 0.9f, 6.5f, true);
                return (shotgun);

            case "Water_gun":
                Weapons_Module.Weapon water_gun = new Weapon(weaponName, 1, 1, bulletSource, normalBulletPrefab, 15, 0.30f, speedMult * 5.0f, 1.5f, 0, false);
                return (water_gun);

            case "Pistol":
                Weapons_Module.Weapon pistol = new Weapon(weaponName, 2, 1, bulletSource, normalBulletPrefab, 10, 0.75f, speedMult * 7.0f, 1.7f, 0f, false);
                return (pistol);

            case "AK47":
                Weapons_Module.Weapon AK47 = new Weapon(weaponName, 3, 2, bulletSource, normalBulletPrefab, 55, 0.35f, speedMult * 7.0f, 1.7f, 0f, false);
                return (AK47);

            case "Revolver":
                Weapons_Module.Weapon revolver = new Weapon(weaponName, 3, 1, bulletSource, normalBulletPrefab, 84, 0.90f, speedMult * 6.0f, 1.4f, 0, false);
                return (revolver);

            case "Uzi":
                Weapons_Module.Weapon uzi = new Weapon(weaponName,1 ,1 , bulletSource, normalBulletPrefab, 24, 0.15f, speedMult * 7.0f, 1.4f, 0, false);
                return (uzi);

            case "M16":
                Weapons_Module.Weapon M40 = new Weapon(weaponName,2 ,2 , bulletSource, normalBulletPrefab, 39, 0.25f, speedMult *7.0f , 1.5f, 0, false);
                return (M40);

            case "Sniper_rifle":
                Weapons_Module.Weapon sniper_rifle = new Weapon(weaponName,5 ,7 , bulletSource, normalBulletPrefab,76 , 1.25f, speedMult *7.0f , 1.8f, 0, false);
                return (sniper_rifle);

            case "Minigun":
                Weapons_Module.Weapon minigun = new Weapon(weaponName, 1, 1, bulletSource, normalBulletPrefab, 45, 0.091f, speedMult *7.0f , 1.7f, 0, false);
                return (minigun);

            case "Rocket_Launcher":
                Weapons_Module.Weapon Rocket_Launcher = new Weapon(weaponName,19 ,1 , bulletSource, normalBulletPrefab, 345, 1.75f, speedMult *3.0f , 1.4f, 0,false);
                return (Rocket_Launcher);

            case "Flame_Thrower":
                Weapons_Module.Weapon Flame_Thrower  = new Weapon(weaponName, 1, 8, bulletSource, normalBulletPrefab, 7, 0.05f, speedMult * 9.0f, 1.9f, 0,false);
                return (Flame_Thrower);

            case "Knife":
                Weapons_Module.Weapon Knife = new Weapon(weaponName, 0, 0, bulletSource, normalBulletPrefab, 30, 0.85f, speedMult * 9.0f , 1.30f, 0,false);
                return (Knife);

            case "Katana":
                Weapons_Module.Weapon Katana = new Weapon(weaponName, 3, 0, bulletSource, normalBulletPrefab, 64, 0.75f, speedMult * 9.0f, 1.5f, 0,false);
                return (Katana);

            case "Axe":
                Weapons_Module.Weapon Axe = new Weapon(weaponName, 4, 0, bulletSource, normalBulletPrefab, 98, 1.35f, speedMult * 8.0f, 1.5f, 0,false);
                return (Axe);

            case "Scythe":
                Weapons_Module.Weapon Scythe = new Weapon(weaponName, 5, 0, bulletSource, normalBulletPrefab, 80, 0.75f, speedMult * 8.0f, 1.5f, 0,false);
                return (Scythe);

            case "Chainsaw":
                Weapons_Module.Weapon Chainsaw = new Weapon(weaponName, 5, 0, bulletSource, normalBulletPrefab, 20, 0.1f, speedMult * 9.0f, 1.4f, 0,false);
                return (Chainsaw);

            case "machine_gun":
                Weapons_Module.Weapon machine_Gun = new Weapon(weaponName, 1, 1, bulletSource, normalBulletPrefab, 10, 0.75f, speedMult * 7.0f, 1.7f, 0f, false);
                return (machine_Gun);

            case "korwins_gun":
                Weapons_Module.Weapon korwins_gun = new Weapon(weaponName, 0, 1, bulletSource, rocketBulletPrefab, 0, 2, speedMult * 10.0f, 100f, 0f, false);
                return (korwins_gun);
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
            selfDamageReceiver.damage_deal(selfDamage);
            lastShotTime = Time.time;

            Transform bulletSourceTransform = bulletSource.GetComponent<Transform>();
            GameObject Bullet = Instantiate(bulletPrefab, bulletSourceTransform.position, bulletSourceTransform.rotation);
            Bullet.GetComponent<bulletScript>().bulletDamage = damage;
            Bullet.GetComponent<bulletScript>().bulletPenetration = penetration;
            Bullet.GetComponent<bulletScript>().owner = bulletSource.GetComponentInParent<Mob>();
            Bullet.GetComponent<Rigidbody2D>().AddForce(Bullet.transform.up * bulletSpeed);

            if (name == "korwins_gun")
            {
                Bullet.AddComponent<Movement>();
                Bullet.GetComponent<Movement>().maxSpeed = 30;
                Bullet.GetComponent<Movement>().speed = 3;
                Bullet.GetComponent<bulletScript>().percentDamage = 5;
            }

            GameObject.Destroy(Bullet, bulletFlightTime);

            

          
            if (isShotgun)
            {
                Debug.Log("Shotty");
                //GameObject Bullet2 = Instantiate(bulletPrefab, bulletSourceTransform.position, bulletSourceTransform.rotation);
                selfDamageReceiver.damage_deal(selfDamage);
                lastShotTime = Time.time;

                Vector2 FirDir = (Bullet.transform.up * bulletSpeed);

                FirDir = RotateAroundAxis(FirDir, spread, bulletSourceTransform.forward);
                bulletSourceTransform = bulletSource.GetComponent<Transform>();
                GameObject Bullet2 = Instantiate(bulletPrefab, bulletSourceTransform.position, bulletSourceTransform.rotation);
                Bullet2.GetComponent<bulletScript>().bulletDamage = damage;
                Bullet2.GetComponent<bulletScript>().bulletPenetration = penetration;
                Bullet2.GetComponent<bulletScript>().owner = bulletSource.GetComponentInParent<Mob>();
                Bullet2.GetComponent<Rigidbody2D>().AddForce(FirDir);
                GameObject.Destroy(Bullet2, bulletFlightTime);

                FirDir = RotateAroundAxis(FirDir, spread, bulletSourceTransform.forward);
                bulletSourceTransform = bulletSource.GetComponent<Transform>();
                GameObject Bullet3 = Instantiate(bulletPrefab, bulletSourceTransform.position, bulletSourceTransform.rotation);
                Bullet3.GetComponent<bulletScript>().bulletDamage = damage;
                Bullet3.GetComponent<bulletScript>().bulletPenetration = penetration;
                Bullet3.GetComponent<bulletScript>().owner = bulletSource.GetComponentInParent<Mob>();
                Bullet3.GetComponent<Rigidbody2D>().AddForce(FirDir);
                GameObject.Destroy(Bullet3, bulletFlightTime);

                FirDir = RotateAroundAxis(FirDir, spread*-3, bulletSourceTransform.forward);
                bulletSourceTransform = bulletSource.GetComponent<Transform>();
                GameObject Bullet4 = Instantiate(bulletPrefab, bulletSourceTransform.position, bulletSourceTransform.rotation);
                Bullet4.GetComponent<bulletScript>().bulletDamage = damage;
                Bullet4.GetComponent<bulletScript>().bulletPenetration = penetration;
                Bullet4.GetComponent<bulletScript>().owner = bulletSource.GetComponentInParent<Mob>();
                Bullet4.GetComponent<Rigidbody2D>().AddForce(FirDir);
                GameObject.Destroy(Bullet4, bulletFlightTime);

                FirDir = RotateAroundAxis(FirDir, spread * -1, bulletSourceTransform.forward);
                bulletSourceTransform = bulletSource.GetComponent<Transform>();
                GameObject Bullet5 = Instantiate(bulletPrefab, bulletSourceTransform.position, bulletSourceTransform.rotation);
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
