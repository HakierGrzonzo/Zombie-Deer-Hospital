using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mob : MonoBehaviour {

    public string title;
    public int bodyDamage;
    public GameObject bulletSource;
    public int HP;
    public int MaxHP;
    public int toughness; // it is a multiplier of a damage dealt and recived
    public int InventorySize=5;
    public string startingWeaponStr;
    public float speed;
    public Weapons_Module.Weapon currentWeapon;
    public Weapons_Module.Weapon[] Inventory;

    private void Start()
    {
        Inventory = new Weapons_Module.Weapon[InventorySize];
        Inventory[0]= Weapons_Module.GetWeapon(startingWeaponStr, bulletSource);
        Inventory[1] = Weapons_Module.GetWeapon("shotgun", bulletSource);
        currentWeapon = Inventory[0];
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (this.gameObject.CompareTag("Enemy")){
            if (collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("Player collision");
                collider.gameObject.GetComponent<Mob>().hit_received(bodyDamage*toughness);
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
