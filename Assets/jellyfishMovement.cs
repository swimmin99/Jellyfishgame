using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Renderer))]
public class jellyfishMovement : MonoBehaviour
{
    public Transform followTransform;

    void Update()
    {
        // Move & Rotate towards Follow Transform
        Vector3 followVector = followTransform.position - transform.position;
        float magnitude = followVector.magnitude;
        if (magnitude > 0.01f)
        {
            transform.up = followVector;
            transform.position += followVector / magnitude
                    * Mathf.Abs(Mathf.Sin(1.5f * Time.time))
                    * Time.deltaTime;
        }
    }
}

