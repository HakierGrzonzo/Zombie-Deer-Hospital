﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{

    public int HP;
    private int MaxHP;
    private const int InventorySize = 5;
    public Item[] Inventory = new Item[InventorySize];

    public bool UseItem(Item UsedItem)
    {
        //Use selected item from the inventory, returned value shows if the item was used
    }

    public Mob(int MaxHP, Item StartingItem)
    {
        this.MaxHP = MaxHP;
        this.Inventory[0] = StartingItem;
        this.HP = MaxHP;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Player : Mob
{

}