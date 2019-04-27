using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mob : MonoBehaviour { 

    public int bodyDamage;
    private int HP;
    public int MaxHP;
    public float toughness; // it is a multiplier of a damage 
    public const int InventorySize=5;
    public string startingWeaponStr;
    public float speed;
    private Weapons_Module.Weapon[] Inventory;

    public Mob(float toughness,int InventorySize, int MaxHP = 100, Weapons_Module.Weapon StartingItem = null)
    {
        this.HP = MaxHP;
        this.MaxHP = MaxHP;
        this.toughness = toughness;
        Inventory = new Weapons_Module.Weapon[InventorySize];
        // this.Inventory[0] = Weapons_Module.getWeapon();
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

    void OnCollisionEnter(Collision collision)
    {
        if (this.gameObject.CompareTag("Enemy")){
            if (collision.collider.CompareTag("Player"))
            {
                Debug.Log("Collision");
                collision.collider.GetComponent<Mob>().hit_received(bodyDamage);
                GameObject.Destroy(this.gameObject);
            }
        }
        
    }

}
