using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class krukke : MonoBehaviour
{

private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destroy()
    {
    // Dette sætter boolen Destroy, som vi kalder i start, til true.
        animator.SetBool("destroy", true);
        // Her kalder jeg BreakCO som er IEnumerator længere nede
        StartCoroutine(breakCO());
    }

    IEnumerator breakCO()
    {
        // Her starter vi med at vente 0.3f, 0,3 sekunder. Dette gør vi så animation kan spilles færdig. Derefter sætter vi objectet til at være deaktiveret så collideren ikke er i vejen.
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
    }


}
