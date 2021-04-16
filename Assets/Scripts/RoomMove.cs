using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{

    public Vector2 CameraChange;
// Dette bruges til hvor meget spilleren skal flyttes. Den skal være vector 3 da vi flytter på playeren
    public Vector3 playerChange;

// Jeg laver en refference til mit cameramovement script
    private CameraMovement cam;

    // Start is called before the first frame update
    void Start()
    {
    // Her kalder jeg mit CameraMovement script. Det gør jeg fordi jeg kommer til at justure public max og min variablerne
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    // Denne command checker om det der er i trigger zonen har tagget Player hvis det er sandt skal cameras offset skiftes
        if(collision.CompareTag("Player"))
        {
        // Her flytter jeg min og max fra mit camera i det nuværende variabler
            cam.minPosition += CameraChange;
            cam.maxPosition += CameraChange;
        // Her flytter jeg også min spiller med cameraet
            collision.transform.position += playerChange;
        }
    }

}
