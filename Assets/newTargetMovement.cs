using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newTargetMovement : MonoBehaviour
{
    public GameObject targetObject;
    float timer = 1f;
    public float timeToMove;
    public float followerMinDistance;
    public float followerMaxDistance;
    Rigidbody rb;
    public bool isHungry;

    //float reboundForce = 100f;


    GameObject[] multipleTargets;

    public float speed = 2.0f;
    float xPos, yPos, zPos;
    public Vector3 desiredPos;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stateCoord();
    }

    void fixedUpdate()
    {
        print(desiredPos);
        timer += Time.deltaTime;
        if (timer >= timeToMove)
        {
            stateCoord();
            transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, desiredPos) <= 0.1f)
            {
                stateCoord();
                timer = 0.0f;
                timeToMove = Random.Range(3f, 5f);
            }
        }
    }


    void stateCoord()
    {
        multipleTargets = GameObject.FindGameObjectsWithTag("Food");
        if (isHungry == true&&multipleTargets!=null)
        {
            print("Hungrystate");
            hungryStateCoord();
        } else if (isHungry == false)
        {
            print("naturalState");
            moveNaturalStateCoord();
        }
    }


    void moveNaturalStateCoord()
    {
        xPos = targetObject.transform.localPosition.x + Random.Range(followerMinDistance, followerMaxDistance);
        yPos = targetObject.transform.localPosition.y + Random.Range(followerMinDistance, followerMaxDistance);
        zPos = targetObject.transform.localPosition.z + Random.Range(followerMinDistance, followerMaxDistance);
        desiredPos = new Vector3(xPos, yPos, zPos);
    }

    void hungryStateCoord()
    { 
        float closestDistance = Mathf.Infinity;
        GameObject finalTarget = null;

        foreach (GameObject go in multipleTargets)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, go.transform.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                finalTarget = go;
            }
        }
       desiredPos = finalTarget.transform.position;
        
    }
}
