using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public int bulletDamage;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") || collider.CompareTag("Enemy"))
        {
            Debug.Log("Hit");
            collider.gameObject.GetComponent<Mob>().hit_received(bulletDamage);
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
