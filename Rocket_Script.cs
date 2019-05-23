using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_Script : MonoBehaviour
{
    public bool isexploding =false;
    public double lifetime = 0.75;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (isexploding)
        {
            gameObject.GetComponent<CircleCollider2D>().radius += 0.05f;
            gameObject.GetComponent<Rigidbody2D>().drag += 5;
            lifetime -= Time.deltaTime;
        }
        if (lifetime < 0) Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name!="Player")
        isexploding = true;


    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(gameObject.transform.position, gameObject.GetComponent<CircleCollider2D>().radius);
    }
}
