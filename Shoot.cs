using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    void Shoot_Weapon(GameObject bulletSource, float destroyTime, int bulletSpeed)
    {
        Transform bulletSourceTransform = bulletSource.GetComponent<Transform>();
        GameObject Bullet = Instantiate(bulletSource, bulletSourceTransform.position, bulletSourceTransform.rotation);
        Bullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.right * bulletSpeed);
    }
}
