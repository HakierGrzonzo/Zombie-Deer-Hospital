using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public int bulletDamage;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if ( collider.CompareTag("Enemy"))//collider.CompareTag("Player") ||
        {
            Debug.Log("Hit");
            collider.gameObject.GetComponent<Mob>().hit_received(bulletDamage);
            GameObject.Destroy(gameObject);
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
