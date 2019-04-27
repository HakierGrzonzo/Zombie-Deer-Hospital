using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mob : MonoBehaviour { 

    private int HP;
    private int MaxHP;
    private float toughness; // it is a multiplier of a damage 
    private const int InventorySize=5;
    public string startingWeaponStr;
    public int speed;
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

}
