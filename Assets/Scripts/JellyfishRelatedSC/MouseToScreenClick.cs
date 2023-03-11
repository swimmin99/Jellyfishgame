using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseToScreenClick : MonoBehaviour
{
    Camera clickDetectingCamera;
    public JellyfishStatusHygine isCleaningComponent;
    private Rigidbody clickDetectingRigidbody;

    void Start()
    {
        clickDetectingCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        isCleaningComponent = GameObject.FindGameObjectWithTag("Jellyfish").GetComponent<JellyfishStatusHygine>();
        clickDetectingRigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseEnter()
    {
        if (isCleaningComponent.isCleaning)
        {
            if (Input.GetMouseButtonDown(0))
            {
                print("click detected");
                Destroy(gameObject);
            }
        }
    }


    void Update()
    {
        //if (isCleaningComponent.isCleaning)
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        Ray clickDetectingRay = clickDetectingCamera.ScreenPointToRay(Input.mousePosition);

        //        if (Physics.Raycast(clickDetectingRay, out RaycastHit hitInfo))
        //        {
        //            print("click detected");
        //            Destroy(gameObject);

        //        }
        //    }

        //}
    }

    

}
