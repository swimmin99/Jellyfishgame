using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetMovement : MonoBehaviour
{
    public GameObject targetObject;
    float timer = 1f;
    public float timerSpeed;
    public float timeToMove;
    public Rigidbody rb;
    float reboundForce = 100f;

    public float speed = 2.0f;
    float xPos, yPos, zPos;
    public Vector3 desiredPos;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        xPos = targetObject.transform.localPosition.x + Random.Range(-1f, 1f);
        yPos = targetObject.transform.localPosition.y + Random.Range(0.5f, 1f);
        zPos = targetObject.transform.localPosition.z + Random.Range(-1f, 1f);
        desiredPos = new Vector3(xPos, yPos, zPos);
    }

    void Update()
    {
        timer += Time.deltaTime * timerSpeed;
        if (timer >= timeToMove)
        {
            rb.AddForce(desiredPos - transform.position);
            //transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * speed);
             if (Vector3.Distance(transform.position, desiredPos) <= 0.1f)
            {
                xPos = targetObject.transform.localPosition.x + Random.Range(-1f, 1f);
                yPos = targetObject.transform.localPosition.y + Random.Range(0.5f, 1f);
                zPos = targetObject.transform.localPosition.z + Random.Range(-1f, 1f);
                desiredPos = new Vector3(xPos, yPos, zPos);
                timer = 0.0f;
                timeToMove = Random.Range(3f, 5f);
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != targetObject)
        {
            print("rebound");
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = -dir.normalized;
            rb.AddForce(dir * reboundForce);
        }
    }

}
