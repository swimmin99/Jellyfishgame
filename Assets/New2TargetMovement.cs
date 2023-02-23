using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class New2TargetMovement : MonoBehaviour
{
    float pastTime= 0f;
    public float timeToMoveMin;
    public float timeToMoveMax;
    float timeToMove;
    public float range = 3f;

    public GameObject followingObject;

    GameObject[] multipleTargets;
    public JellyfishStatusHunger jellyfishstatusHunger;

    public float speed = 1.0f;
    Vector3 location;

    private void Start()
    {
        stateCoord();
        timeToMove = 0f;
        jellyfishstatusHunger = followingObject.GetComponent<JellyfishStatusHunger>();
    }

    public void FixedUpdate()
    {
        
        
        if (GameObject.FindGameObjectWithTag("Food")&& jellyfishstatusHunger.isHungry)
        {
            print("persuit on");
            HungryStateCoord();
            transform.position = Vector3.Lerp(transform.position, location, Time.deltaTime * speed);

        }
        else
        {
            pastTime += Time.deltaTime;

            if (pastTime >= timeToMove)
            {
                transform.position = Vector3.Lerp(transform.position, location, Time.deltaTime * speed);
                
            }

            if (Vector3.Distance(transform.position, location) <= 0.2f)
            {
                stateCoord();
                pastTime = 0f;
                timeToMove = Random.Range(timeToMoveMin, timeToMoveMax);
            }

        }

    }


    void stateCoord()
    {

        
            naturalStateCoord();

    }

    void naturalStateCoord()
    {
       location = new Vector3(followingObject.transform.position.x + Random.Range(-1*range, range),
       followingObject.transform.position.y + Random.Range(-1.5f, 1.5f),
       followingObject.transform.position.z + Random.Range(-1*range, range));
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

}
