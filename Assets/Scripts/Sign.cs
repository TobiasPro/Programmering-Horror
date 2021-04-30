using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sign : MonoBehaviour
{
    // En reference til dialog boksen og teksten og den sidste er til string som skal være i dialogen
    public GameObject dialogBoks;
    public Text dialogText;
    public string dialog;
    // Så bruger vi en bool til at bestemme om dialog boksen skal være aktiv
    public bool playerInRange; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
           // Her checker vi om dialog boksen er aktiv i Hierarchy. Hvis den er aktiv vil koden deaktivere det og hvis den er deaktiveret vil koden aktivere det.
            // Efter at det er blevet sat aktivt igen, ændrer vi så teksten.
            if(dialogBoks.activeInHierarchy)
            {
                dialogBoks.SetActive(false);
            }else{
                dialogBoks.SetActive(true);
                dialogText.text = dialog;
            }
        }
        
    }
    // Dette kode holder styr på når tagget Player indtræder collider zonen
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    //  Dette kode holder styr på når tagget Player forlader collider zonen

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerInRange = false;
            // Hvis spilleren går ud af skiltet colider rækkevidde skal dialogboksen deaktiveres 
            dialogBoks.SetActive(false);
        }
    }
}
