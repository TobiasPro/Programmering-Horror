using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An enum is a special "class" that represents a group of constants (unchangeable/read-only variables).
public enum PlayerState
{
    walk,
    attack,
    interact
}
public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    // Vi laver den public så den kan ændres i unity inspector
    public float speed;
    // Her laver jeg refference til min players rigidbody 
    private Rigidbody2D myRigidbody;

    // Her styre jeg hvor meget playerens position skal ændres. Vector3 bruges fordi man skal kan gå op, ned og til siderne
    private Vector3 movement;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Grunden til vi har en normal update og en fixedupdate er fordi vi startede med at lave vores update om til fixedupdate
    // dette resulterede i at attack animation ikke afspillede korrekt fordi hvis man ikke trykkede på space i det konstant framerate
    // fixedupdate kører i ville animation ikke afspilles. Vi havede dog også brug for fixedupdate da det er en konstant framerate
    // da vi ikke havede fixedupdate oplevede vi at karakteren ikke havede samme hastighed på forskellige computere fordi update ikke kører med konstant framerate.
    void Update()
    {
        // For hvert frame resetter jeg hvor meget player har ændret sig
        movement = Vector3.zero;

        // Man bruger GetAxisRaw for at undgå acceleration eller modstands acceleration som gør movement kommer til føle mere "snappy"
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack)
        {
            // StartCoroutine Kan stoppe koden i noget tid og så komme tilbage og ændre noget andet kode unden at lave en timeout
            StartCoroutine(AttackCo());
        }

        else if (currentState == PlayerState.walk)
        {
            // Laver en refference til UpdateAnimationAndMove
            UpdateAnimation();
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        // Her putter jeg en forsinkelse før koden forsætter null betyder 1 frame. Så vi venter 1 frame.
        yield return null;
        animator.SetBool("attacking", false);
        // .33 er hvor lang tid det tager spilleren at spille attack animatioen
        yield return new WaitForSeconds(.33f);
        // Her resetter vi spillerens state så spilleren kan gå igen efter at have attacked
        currentState = PlayerState.walk;
    }

    // FixedUpdate kører med en konstant frame per second, dette er vigtigt når vi styrer player movement. Da vi kun brugte update oplevede vi fejl med at kunne gå igennem colliders
    void FixedUpdate()
    {
        if (movement != Vector3.zero)
        {
            MoveCharacter();
        }
    }

    // Laver en update mere fordi den jeg allerede har er ved at blive ret proppet så for at holde ting organiseret laver jeg en spicifik til animator
    void UpdateAnimation()
    {
        // Hvis change ikke er = Vector3.zero kalder jeg scriptet MoveCharacter
        if (movement != Vector3.zero)
        {
            // Her sætter jeg move x = til change.x og moveY = til change.y. Derefter ved programmet hvilke animationer den skal afspille baseret på hvilken værdi der bevæger sig
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            // Her gør vi så walk animations spiller når moving = true
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }


    // Her laver vi en ny metode som kør det muligt at flytte player via onscreen metoder
    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            // Først tager jeg spillerens position. Her tilføjer jeg change som er 1 og gange det med speed. Deltatime ganger så det tid der er gået fra den forigårende frame, hvilket er et meget lille nummer. Dette gør at når spilleren bevæger sig føles det mere smooth
            transform.position + movement * speed * Time.deltaTime);
    }

}
