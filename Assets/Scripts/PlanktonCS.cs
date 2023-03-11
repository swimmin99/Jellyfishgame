using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanktonCS : MonoBehaviour
{
    float timepast;
    float lifetime=3f;


    void Start()
    { 
        timepast = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timepast += Time.deltaTime;
        if(timepast > lifetime)
        {
            Destroy(gameObject);
        }
    }
}
