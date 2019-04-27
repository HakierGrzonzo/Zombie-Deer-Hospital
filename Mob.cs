using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mob : MonoBehaviour {

    public string title = "Miszorek";
    public int bodyDamage;
    public GameObject bulletSource;
    public int HP;
    public int MaxHP;
    public int toughness; // it is a multiplier of a damage dealt and recived
    public const int InventorySize=5;
    public string startingWeaponStr;
    public float speed;
    public Weapons_Module.Weapon currentWeapon;
    public Weapons_Module.Weapon[] Inventory;

    public Mob(string title, int toughness, int InventorySize, int MaxHP = 100, string StartingItem = null, GameObject bulletSource=null)
    {
        this.title = title;
        this.HP = MaxHP;
        this.MaxHP = MaxHP;
        this.toughness = toughness;
        Inventory = new Weapons_Module.Weapon[InventorySize];
        this.Inventory[0] = GetWeapon(StartingItemStr);
        this.HP = MaxHP;
        this.title = title;
    }


    private void Start()
    {
        currentWeapon = Inventory[0];
    }

    public Weapons_Module.Weapon GetWeapon(string weaponName)
    {
        float speedMult = 40f;
        switch (weaponName)
        {
            case "shotgun":
                Weapons_Module.Weapon shotgun = new Weapons_Module.Weapon(bulletSource, Weapons_Module.normalBulletPrefab, 20, 0.90f, speedMult*5.5f, 0.9f, 6.5f, true, false);
                return (shotgun);

            case "water_gun":
                Weapons_Module.Weapon water_gun = new Weapons_Module.Weapon(bulletSource, Weapons_Module.normalBulletPrefab, 15, 0.30f, speedMult * 5.0f, 1.5f, 0, false, false);
                return (water_gun);

            case "pistol":
                Weapons_Module.Weapon pistol = new Weapons_Module.Weapon(bulletSource, Weapons_Module.normalBulletPrefab, 10, 0.75f, speedMult * 7.0f, 1.7f, 0f, false, false);
                return (pistol);

            case "machine_Gun":
                Weapons_Module.Weapon machine_Gun = new Weapons_Module.Weapon(bulletSource, Weapons_Module.normalBulletPrefab, 10, 0.75f, speedMult * 7.0f, 1.7f, 0f, false, false);
                return (machine_Gun);

        }
        return null;
    }

    public void hit_received(int damage)
    {
        HP = (int)((float)HP - ((float)damage) * toughness);
    }


    private void Update()
    {
        if (HP > 0)
        { }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
        if (HP> MaxHP)
        {
            HP = MaxHP;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (this.gameObject.CompareTag("Enemy")){
            if (collision.collider.CompareTag("Player"))
            {
                Debug.Log("Collision");
                collision.collider.GetComponent<Mob>().hit_received(bodyDamage*toughness);
                GameObject.Destroy(this.gameObject);
            }
        }

    }
    //deconstructor - death sequence
    ~Mob()
    {
        //drop weapon, NEED WEAPON PREFAB
    }
}
