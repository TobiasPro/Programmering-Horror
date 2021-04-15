using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   
// laver en refference til hvad kameraet skal følge
    public Transform target;
// Variable styrer hvor hurtigt kameraet skal styres imod target
    public float smoothing;
// Laver en public vector2 som har en x og y position
    public Vector2 maxPosition;
    public Vector2 minPosition;
    void Start()
    {
        
    }

    // LateUpdate is called after all Update functions have been called. This is useful to order script execution. For example a follow camera should always be implemented in LateUpdate because it tracks objects that might have moved inside Update.
    void LateUpdate()
    {
        // Hvis vores transform position ikke er vores target position så skal man flytte til target
        if(transform.position != target.position)
        {
            // Her laves der en ny Vector3 som gør at cameraet vil følge spillerens x og y position men beholde sin egen z position for at holde afstand fra player. Uden denne Vector vil cameraet gå ind i playeren og derved kan man ikke se mappet.
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            
        // Clamp bruges til at låse cameraets position imellem to x og y værdier. Dette bruges til at gøre så kameraet ikke går ud over væggene
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
        // Over brugte jeg Clamp til at lave en max position for x og y til mit camera og nu laver jeg det samme til y
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            // Interpolerer lineært mellem to punkter. Først tager man transform.position som er vores nuværende position. Derefter er targetPosistionen hvor vi vil være. Og til sidst er smoothing det antal vi vil dække.
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
