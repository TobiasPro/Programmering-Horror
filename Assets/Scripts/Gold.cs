using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{

    private GoldManager pm;
    // Her laver jeg en public hvor jeg kan vælge hvilken lydfil der skal spilles ved opsamling af mønt
    public AudioClip PickUpAudioClip;

    // Start is called before the first frame update
    void Start()
    {
    pm = GameObject.Find("GoldManager").GetComponent<GoldManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            // Her bestemmer man værdien af points
           pm.AddPoint(1);
            // Her sørger vi for at clippet som vi refferede til i public bliver spillet. Når mønten bliver taget op. Transform position betyder bare clippet bliver spillet hvor vi er.
          AudioSource.PlayClipAtPoint(PickUpAudioClip, transform.position);
            Destroy(gameObject);
        }
    }

}
