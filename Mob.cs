using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour { 

    public int HP;
    private int MaxHP;
    public const int InventorySize=5;
    public Item[] Inventory = new Item[InventorySize];
    
    /*
    public bool UseItem(Item UsedItem)
    {
        return false;
        //Use selected item from the inventory, returned value shows if the item was used
    }
    */
    /*
    public Mob(int MaxHP=100, Item StartingItem=null)
    {
        this.MaxHP = MaxHP;
        this.Inventory[0] = StartingItem;
        this.HP = MaxHP;
    }
    */
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
*/
}
