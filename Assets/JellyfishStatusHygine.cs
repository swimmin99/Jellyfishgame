using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JellyfishStatusHygine : MonoBehaviour
{
    //variables
    public float health;

    private int stainNum;
    private int startSickWhen = 1;

    public bool isSick;
    public bool isCuring;
    public bool isCleaning;
    //componenets&objects
    Color originalMaterialColor;

    

    //componenets,objects
    Camera clickDetectingCamera;
    private Rigidbody clickDetectingRigidbody;
    private Renderer jellyfishRenderer;
    private StainController stainControllerCP;
    public TMP_Text hygineStatusTextObject;


    void Start()
    {
        isCuring = false;
        isCleaning = false;
        jellyfishRenderer = GetComponent<Renderer>();
        stainControllerCP = GameObject.FindGameObjectWithTag("StainController").GetComponent<StainController>();

        isSick = false;


        clickDetectingCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        clickDetectingRigidbody = GetComponent<Rigidbody>();
        //originalMaterialColor = jellyfishRenderer.material.color;

    }

    void Update()
    {
        hygineStatusTextObject.text = "Clean + " + isSick.ToString();

        stainNum = stainControllerCP.stainCountMethod();
        if (stainNum >= startSickWhen)
        {
            sickStatusChange(true);
        }



        if (isCuring)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray clickDetectingRay = clickDetectingCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(clickDetectingRay, out RaycastHit hitInfo))
                {
                    print("cure click detected");
                    sickStatusChange(false);

                }
            }

        }
    }


    public void sickStatusChange(bool boolean)
    {
        if(boolean == true)
        {
            isSick = true;
            jellyfishRenderer.material.color = Color.green;
        } else
        {
            isSick = false;
            jellyfishRenderer.material.color = originalMaterialColor;
        }
    }


    public void isCleaningStatusChange()
    {
        if(isCleaning == false)
        {
            isCleaning = true;
        } else
        {
            isCleaning = false;
        }
    }

    public void isCuringStatusChange()
    {
        if(isCuring == false)
        {
            isCuring = true;
        } else
        {
            isCuring = false;
        }
    }

}
