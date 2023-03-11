using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StainController : MonoBehaviour
{
    float pastTime = 0f;
    float targetTime = 20f;
    public int stainCount;
    public GameObject targetStain;
    // Start is called before the first frame update
    void Start()
    {
        stainCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pastTime += Time.deltaTime;
        if(pastTime >= targetTime)
        {
            Instantiate(targetStain, transform);
            pastTime = 0;
        }
    }


    public int stainCountMethod()
    { 
        return transform.childCount;
    }
}
