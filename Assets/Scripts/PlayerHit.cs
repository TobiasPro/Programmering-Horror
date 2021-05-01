using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Breakable"))
        {
            // Dette referer til scriptet Pot. Og så kalder funktionen Destroy i Pot. Dette bliver kaldt hvis vores spiller colliders hitbox collider med noget der har tagget breakable
            collision.GetComponent<krukke>().Destroy();
        }
    }
}
