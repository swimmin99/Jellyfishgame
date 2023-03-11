using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankSizerSc : MonoBehaviour
{

    public Camera mymainCamera;
    Vector3 screenPosition;

    // Start is called before the first frame update
    void Start()
    {
        screenPosition = mymainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Vector3.Distance(transform.position, mymainCamera.transform.position)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
