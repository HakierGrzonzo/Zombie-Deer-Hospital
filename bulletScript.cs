using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public int bulletDamage;
    public Mob owner;
    public int bulletPenetration;



    void OnTriggerEnter2D(Collider2D collider)
    {
        if ( collider.CompareTag("Enemy"))//collider.CompareTag("Player") ||
        {
            Debug.Log("Hit");
            if (collider.gameObject.GetComponent<Mob>().hit_received(bulletDamage) != null)
            {
                owner.HP += collider.gameObject.GetComponent<Mob>().healthDrop;
            }

            bulletPenetration -= 1;
            if (bulletPenetration <= 0)
            {
                GameObject.Destroy(gameObject);
            }
            
        }

        else if (collider.CompareTag("Player"))
        {
            
        }

        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
