using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public string weaponToDropName;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))    //when e pressed   collision.gameObject.name == "Player"
        {
            if (collision.gameObject.CompareTag("Player"))    //when player enters an item drop
            {
                Mob playerMob = collision.gameObject.GetComponent<Mob>();
                Weapons_Module.Weapon weaponToGive = Weapons_Module.GetWeapon(weaponToDropName, playerMob.bulletSource);
                int weaponToDropTier = weaponToGive.tier;
                playerMob.DropWeapon(weaponToDropTier);
                playerMob.GiveWeapon(weaponToGive);
                Debug.Log("Weapon Given");


                /*
                GameObject OwnWeaponDrop;
                OwnWeaponDrop = Instantiate(gameObject, player.transform.position, Quaternion.identity);
                int Index = gameObject.GetComponent<Player_Control>().currentWeaponIndex;
                OwnWeaponDrop.GetComponent<GiveWeapon>().weaponname = collision.gameObject.GetComponent<Mob>().Inventory[Index].name;

                Debug.Log("dropping " + gameObject.GetComponent<GiveWeapon>().weaponname);

                Debug.Log("giving " + weaponname);
                collision.gameObject.GetComponent<Mob>().Inventory[Weapons_Module.GetWeapon(weaponname, collision.gameObject.GetComponent<Mob>().bulletSource).tier - 1] = Weapons_Module.GetWeapon(weaponname, collision.gameObject.GetComponent<Mob>().bulletSource);
                Destroy(gameObject);      
                */
            }
        }
    }
    /*
 * Disclaimer: obtaining weapon may require swith in and out of it for refreshing - upon picking up AK swith to gun1 and back to gun2 for best results
 */
  


}
