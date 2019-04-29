using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mob : MonoBehaviour {

    public string title;
    public int bodyDamage;
    public int healthDrop;
    public GameObject bulletSource;
    public int HP;
    public int MaxHP;
    public int toughness; // it is a multiplier of a damage dealt and recived
    public int InventorySize;
    public string startingWeaponStr;
    public string secondWeaponStr;
    public string thirdWeaponStr;

    public float speed;
    public Weapons_Module.Weapon currentWeapon;
    public string currentWeaponStr;
    public Weapons_Module.Weapon[] Inventory;

    private void Start()
    {
        if (InventorySize > 0)
        {
            Inventory = new Weapons_Module.Weapon[InventorySize];
        }

        if (startingWeaponStr != null)
        {
            Inventory[0] = Weapons_Module.GetWeapon(startingWeaponStr, bulletSource);
            currentWeapon = Inventory[0];
        }
        else
        {
            Inventory[0] = Weapons_Module.GetWeapon("Nothing1", bulletSource);
        }

        if (secondWeaponStr != null)
        {
            Inventory[1] = Weapons_Module.GetWeapon(secondWeaponStr, bulletSource);
        }
        else
        {
            Inventory[1] = Weapons_Module.GetWeapon("Nothing2", bulletSource);
        }

        if (thirdWeaponStr != null)
        {
            Inventory[2] = Weapons_Module.GetWeapon(thirdWeaponStr, bulletSource);
        }
        else
        {
            Inventory[2] = Weapons_Module.GetWeapon("Nothing3", bulletSource);
        }
    }

    public int GetCurrentWeaponIndex()
    {
        return( Array.IndexOf(Inventory, currentWeapon));
    }

    public string damage_deal(int damage)
    {
        HP = (int)((float)HP - ((float)damage) * toughness);
        if (HP <= 0)
        {
            return title;
        }
        else
        {
            return null;
        }
    }

    public void GiveWeapon(Weapons_Module.Weapon weapon)
    {
        int weaponToGiveTier = weapon.tier;
        int currentWeaponIndex = GetCurrentWeaponIndex();
        Inventory[weaponToGiveTier-1] = weapon;
        if(weaponToGiveTier-1 == currentWeaponIndex)
        {
            currentWeapon = Inventory[weaponToGiveTier - 1];
        }
    }

    public void DropWeapon(int inventorySlot)
    {
        if (Inventory[inventorySlot] != null)
        {
            GameObject droppedWeapon = Instantiate(Weapons_Module.droppedWeaponPrefab, gameObject.transform.position, Quaternion.identity);
            droppedWeapon.GetComponent<SpriteRenderer>().sprite = Weapons_Module.GetWeaponSprite(Inventory[inventorySlot].name);
            droppedWeapon.GetComponent<WeaponPickup>().weaponToDropName = Inventory[inventorySlot].name;
        }
        Inventory[inventorySlot] = Weapons_Module.GetWeapon("Nothing"+(inventorySlot +1).ToString(), bulletSource);
    }

    public string Percent_damage_deal_MaxHP(int percentDamage)
    {
        MaxHP = MaxHP- MaxHP*(percentDamage/100);
        if (HP <= 0)
        {
            return title;
        }
        else
        {   
            return null;
        }
    }

    private void Update()
    {
        if (gameObject.CompareTag("Player"))
        {
            currentWeapon = Inventory[GetCurrentWeaponIndex()];
            if (currentWeapon != null)
            {
                //Debug.Log(currentWeapon.name);
            }
            else
            {
                //Debug.Log("fucked up");
            }

            currentWeaponStr = currentWeapon.name;
        }
        
        
        if (HP > 0)
        { }
        else if(HP<=0)
        {
            HP = 0;
            //GameObject.Destroy(this.gameObject);
        }
        if (HP > MaxHP)
        {
            HP = MaxHP;
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (this.gameObject.CompareTag("Enemy")){
            if (collider.gameObject.CompareTag("Player"))
            {
                if(collider.gameObject.GetComponent<Mob>().damage_deal(bodyDamage*toughness) != null)
                {
                    GameObject.Destroy(collider.gameObject);
                }
                GameObject.Destroy(gameObject.gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        Camera.main.GetComponent<statKeeper>().addKill(gameObject.name);
    }

}
