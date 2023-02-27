using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moenyCS : MonoBehaviour
{
    Camera clickDetectingCamera;
    private Rigidbody clickDetectingRigidbody;
    GameObject jellyfishOb;
    prototypeStageController moneyStageComponenet;
    public JellyfishStatusHygine isCleaningComponent;

    private Renderer targetRenderer;
    public Color MouseOnColor1;
    public Color MouseOffColor2;
    bool mouseOnTarget;
    // Start is called before the first frame update
    void Start()
    {
        moneyStageComponenet = GameObject.FindGameObjectWithTag("StageController").GetComponent<prototypeStageController>();
        clickDetectingCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        clickDetectingRigidbody = GetComponent<Rigidbody>();
        targetRenderer = GetComponent<Renderer>();
        
        mouseOnTarget = false;
    }

    // Update is called once per frame
    void Update()
    { 
            
        if (Input.GetMouseButtonDown(0)&&mouseOnTarget)
            {
                moneyStageComponenet.money += 10;
                print("money click detected");
            Destroy(transform.parent.gameObject);
        }

    }


    private void OnMouseEnter()
    {
            targetRenderer.material.color = MouseOnColor1;
        mouseOnTarget = true;
            
    }

    private void OnMouseExit()
    {
            targetRenderer.material.color = MouseOffColor2;
        mouseOnTarget = false;
    }

    private void OnMouseDown()
    {

    }


}
