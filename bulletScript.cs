using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public int bulletDamage;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("Hit");
            collision.collider.gameObject.GetComponent<Mob>().hit_received(bulletDamage);
        }
    }
}
