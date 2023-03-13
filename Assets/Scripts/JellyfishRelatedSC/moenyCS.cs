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
    public Material myMaterial;
    private Renderer targetRenderer;
    public Color MouseOnColor1;
    public Color MouseOffColor2;
    bool mouseOnTarget;

    public int minimumMoney;
    public int addedMoneyRatio;

    // Start is called before the first frame update
    void Start()
    {
        moneyStageComponenet = GameObject.FindGameObjectWithTag("StageController").GetComponent<prototypeStageController>();
        clickDetectingCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        clickDetectingRigidbody = GetComponent<Rigidbody>();
        targetRenderer = GetComponent<Renderer>();
        GetComponentInChildren<MeshRenderer>().material.CopyPropertiesFromMaterial(myMaterial);
       // GetComponentInChildren<MeshRenderer>().GetComponentInChildren<MeshRenderer>().sharedMaterial = myMaterial;
        mouseOnTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        print(minimumMoney * addedMoneyRatio);
        print(minimumMoney + " " + addedMoneyRatio);
        if (Input.GetMouseButtonDown(0)&&mouseOnTarget)
            {
                moneyStageComponenet.money += minimumMoney * addedMoneyRatio;
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
