using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public int bulletDamage;
    public int bulletPenetration;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if ( collider.CompareTag("Enemy"))//collider.CompareTag("Player") ||
        {
            Debug.Log("Hit");
            collider.gameObject.GetComponent<Mob>().hit_received(bulletDamage);

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
