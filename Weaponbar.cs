using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponbar: MonoBehaviour
{                   
    public SpriteRenderer Slot1;
    public SpriteRenderer Slot2;
    public SpriteRenderer Slot3;
    public SpriteRenderer SelectVisualizer;

    void Update()
    {

        //This controls the grey highlight over the Weapon Bar
        int Index = gameObject.GetComponentInParent<Mob>().GetCurrentWeaponIndex();
        if (Index == 0) { SelectVisualizer.transform.position = Slot1.transform.position; }
        else if (Index == 1) { SelectVisualizer.transform.position = Slot2.transform.position; }
        else if (Index == 2) { SelectVisualizer.transform.position = Slot3.transform.position; }


        //This ensures that the weapon picked up is equipped to the correct slot
        foreach (Weapons_Module.Weapon Gun in gameObject.GetComponentInParent<Mob>().Inventory)
        {
            if (Gun != null)
            {
                if (Gun.tier == 1)
                {
                    Slot1.sprite = Weapons_Module.GetWeaponSprite(Gun.name);
                }

                else if (Gun.tier == 2)
                {
                    Slot2.sprite = Weapons_Module.GetWeaponSprite(Gun.name);
                }

                else if (Gun.tier == 3)
                {
                    Slot3.sprite = Weapons_Module.GetWeaponSprite(Gun.name);
                }
            }
            
            
            

            /*
            if (Gun.name=="Pistol") { Slot1.sprite = Weapons_Module.GetWeaponSprite("Pistol"); }
            else if (Gun.name=="Uzi") { Slot1.sprite = Weapons_Module.GetWeaponSprite("Uzi"); }
            else if (Gun.name== "Revolver") { Slot1.sprite = Weapons_Module.GetWeaponSprite("Revolver"); }
            else if (Gun.name== "Knife") { Slot1.sprite = Weapons_Module.GetWeaponSprite("Knife"); }
            else if (Gun.name== "Shotgun") { Slot2.sprite = Weapons_Module.GetWeaponSprite("Shotgun"); }
            else if (Gun.name== "AK47") { Slot3.sprite = Weapons_Module.GetWeaponSprite("AK47"); }
            else if (Gun.name== "M40"|| Gun.name == "M16") {Slot2.sprite = Weapons_Module.GetWeaponSprite("M16"); }
            */

        }
    }
}
