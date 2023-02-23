using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodCS : MonoBehaviour
{
    
    float pastTime = 0f;
    float maxTime = 100f;
    GameObject slime;
    // Start is called before the first frame update
    void Start()
    {
        slime = GameObject.FindGameObjectWithTag("Jellyfish");    
    }

    // Update is called once per frame
    void Update()
    {
        pastTime += Time.deltaTime;
        if (pastTime > maxTime)
        {
            Destroy(gameObject);
        }

        if (Vector3.Distance(transform.position, slime.transform.position) < 1f && slime.GetComponent<JellyfishStatusHunger>().isHungry == true)
        {
            slime.GetComponent<JellyfishStatusHunger>().foodIntake(50);
            Destroy(gameObject);
        }

    }
  
}
