using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAI : MonoBehaviour
{
    //en public Array, så den kan store dens position
    public Transform[] patrolPoints;
    public float speed; 
    Transform currentPatrolPoint;
    int currentPatrolIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints [currentPatrolIndex];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (Vector3.up * Time.deltaTime * speed);
        //er han ved patrol point?
        if(Vector3.Distance (transform.position,currentPatrolPoint.position) <.1f)
        {
            //Du er ved patrol point, så får vi fandt ved den næste
            //If statement ser om vi har flere patrol points - hvis ikke gå tilbage til point.1
            if(currentPatrolIndex +1 < patrolPoints.Length) {
                currentPatrolIndex++;
            } else {
                currentPatrolIndex = 0;
            currentPatrolIndex = 0;
            }
            currentPatrolPoint = patrolPoints [currentPatrolIndex];
        }
//Vector3 får den sprite til at vende mod den næste patrol point, og finder også den retning af vektor pointet
            Vector3 patrolPointsDir = currentPatrolPoint.position - transform.position;
            float angle = Mathf.Atan2 (patrolPointsDir.y, patrolPointsDir.x) * Mathf.Rad2Deg - 90f;
//mathematisk funktion som hjælper med at vende mod den retning enemies er rettet mod
            Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
//rotation til ud transformering. 
            transform.rotation = Quaternion.RotateTowards (transform.rotation, q, 180f);

    }
}
