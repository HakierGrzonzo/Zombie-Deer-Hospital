using UnityEngine;

public class Item : MonoBehaviour
{
    public string Name;
    public static int SpawnRate; //lower value => higher tier
    public float FireRate;
    public static float CostPerShot;
    public float Spread;
    public bool IsShotgun;
    public bool CurrentlyEquipped;
    public string SpritePath; //nazwa pliku z grafiką

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
