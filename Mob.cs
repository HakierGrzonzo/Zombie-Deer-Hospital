using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mob : MonoBehaviour { 

    public int HP;
    private int MaxHP;
    public const int InventorySize=5;
    public Weapons_Module.Weapon[] Inventory = new Weapons_Module.Weapon[InventorySize];

    public Mob(int MaxHP=100, Weapons_Module.Weapon StartingItem =null)
    {
        this.MaxHP = MaxHP;
        this.Inventory[0] = StartingItem;
        this.HP = MaxHP;
    }
    
}
