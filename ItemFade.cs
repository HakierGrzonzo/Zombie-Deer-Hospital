using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFade : MonoBehaviour {

    public float Lifetime;
	
	// Update is called once per frame
	void Update ()
    {
        if (Lifetime < 0) { Destroy(gameObject); }
        else { Lifetime -= Time.deltaTime; }
        
	}
}
