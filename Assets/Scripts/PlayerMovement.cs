using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   // Vi laver den public så den kan ændres i unity inspector
   public float speed; 
    // Her laver jeg refference til min players rigidbody 
    private Rigidbody2D myRigidbody;

    // Her styre jeg hvor meget playerens position skal ændres
    private Vector3 change;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    // For hvert frame resetter jeg hvor meget player har ændret sig
        change = Vector3.zero;

    // Man bruger GetAxisRaw for at undgå acceleration eller modstands acceleration som gør movement kommer til føle mere "snappy"
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        
    // Laver en refference til UpdateAnimationAndMove
        UpdateAnimationAndMove();
    }

// Laver en update mere fordi den jeg allerede har er ved at blive ret proppet så for at holde ting organiseret laver jeg en spicifik til animator
void UpdateAnimationAndMove()
{
    // Hvis change ikke er = Vector3.zero kalder jeg scriptet MoveCharacter
            if(change != Vector3.zero)
        {
            MoveCharacter();
            // Her sætter jeg move x = til change.x og moveY = til change.y. Derefter ved programmet hvilke animationer den skal afspille baseret på hvilken værdi der bevæger sig
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
        // Her gør vi så walk animations spiller når moving = true
            animator.SetBool("moving", true);
        }else{
            animator.SetBool("moving", false);
        }
}


    // Her laver vi en ny metode som kør det muligt at flytte player via onscreen metoder
    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            // Først tager jeg spillerens position. Her tilføjer jeg change som er 1 og gange det med speed. Deltatime ganger så det tid der er gået fra den forigårende frame, hvilket er et meget lille nummer. Dette gør at når spilleren bevæger sig føles det mere smooth
            transform.position + change * speed * Time.deltaTime);
    }

}
