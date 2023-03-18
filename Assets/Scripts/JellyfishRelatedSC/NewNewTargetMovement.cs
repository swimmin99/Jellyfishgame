using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewNewTargetMovement : MonoBehaviour
{
    float pastTime = 0f;
    public float timeToMoveMin;
    public float timeToMoveMax;
    float timeToMove;
    public float range = 3f;

    public GameObject followingObject;

    GameObject[] multipleTargets;
    public JellyfishStatusHunger jellyfishstatusHunger;

    public float speed = 1.0f;

    Vector3 movingLimit;


    Vector3 location;
    Vector3 pointA;
    Vector3 pointB;
    Vector3 pointC;


    

    private void Start()
    {
        movingLimit = new Vector3(GameObject.FindGameObjectWithTag("StageController").GetComponent<prototypeStageController>().movingLimitX,
                                    GameObject.FindGameObjectWithTag("StageController").GetComponent<prototypeStageController>().movingLimitY,
                                    GameObject.FindGameObjectWithTag("StageController").GetComponent<prototypeStageController>().movingLimitZ);


        pastTime = 0.1f;
        timeToMove = Random.Range(timeToMoveMin, timeToMoveMax);
        naturalStateCoord();
        jellyfishstatusHunger = followingObject.GetComponent<JellyfishStatusHunger>();
    }

    public void FixedUpdate()
    {

        if (GameObject.FindGameObjectWithTag("Food") && jellyfishstatusHunger.isHungry)
        {
            print("persuit on");
            HungryStateCoord();
            transform.position = Vector3.Lerp(transform.position, location, Time.deltaTime * speed);
           

        }
        else
        {
           pastTime += Time.deltaTime;
           transform.position = GetPointOnBezierCurve(transform.position, pointA, pointB, pointC, pastTime / timeToMove);
           if(pastTime >= timeToMove)
            {
                timeToMove = Random.Range(timeToMoveMin, timeToMoveMax);
                pastTime = 0.1f;
                naturalStateCoord();
                
            }

        }
    }



    void naturalStateCoord()
    {
        pointA = transform.position;

        pointB = new Vector3(transform.position.x + Random.Range(-1 * range, range),
            transform.position.y + Random.Range(-1 * range, range),
            transform.position.z + Random.Range(-1 * range, range));

        pointC = new Vector3(Random.Range(-movingLimit.x * 0.8f, movingLimit.x * 0.8f),
                        Random.Range(-movingLimit.y * 0.8f, movingLimit.y * 0.8f),
                        Random.Range(-movingLimit.y * 0.8f, movingLimit.y * 0.8f));

    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(pointA, 0.1f);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(pointB, 0.1f);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(pointC, 0.1f);

    }

    void HungryStateCoord()
    {
        multipleTargets = GameObject.FindGameObjectsWithTag("Food");
        float closestDistance = Mathf.Infinity;
        foreach (GameObject go in multipleTargets)
        {
            float currentDistance = Vector3.Distance(transform.position, go.transform.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                location = go.transform.position;
            }
        }

    }


    Vector3 GetPointOnBezierCurve(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        float u = 1f - t;
        float t2 = t * t;
        float u2 = u * u;
        float u3 = u2 * u;
        float t3 = t2 * t;

        Vector3 result =
            (u3) * p0 +
            (3f * u2 * t) * p1 +
            (3f * u * t2) * p2 +
            (t3) * p3;



        return result;
    }
}