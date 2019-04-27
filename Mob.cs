using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mob : MonoBehaviour {

    public int bodyDamage;
    private GameObject bulletSource;
    public int HP;
    public int MaxHP;
    public int toughness; // it is a multiplier of a damage dealt and recived
    public const int InventorySize=5;
    public string startingWeaponStr;
    public float speed;
    public Weapons_Module.Weapon[] Inventory;

    public Mob(int toughness,int InventorySize, int MaxHP = 100, string StartingItem = null, GameObject bulletSource=null)
    {
        this.HP = MaxHP;
        this.MaxHP = MaxHP;
        this.toughness = toughness;
        Inventory = new Weapons_Module.Weapon[InventorySize];
        Weapons_Module.Weapon startingWeapon = Weapons_Module.GetWeapon(StartingItem);
        startingWeapon.bulletSource = bulletSource;
        this.Inventory[0] = Weapons_Module.GetWeapon(StartingItem);
        this.HP = MaxHP;
    }

    //returns true if the mob dies
    public bool hit_received(int damage)
    {
        HP = (int)((float)HP - ((float)damage) * toughness);
        if (HP > 0)
        {
            return false;
        }
        else
        {
            GameObject.Destroy(this.gameObject);
            return true;
        }

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
