using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JellyfishButtonCS : MonoBehaviour
{
    //public GameObject parentCanvas;
    public GameObject popUpUIPrefab;
    public GameObject selfOB;
    public GameObject stageControllerObj;

    public int buttonNumber;
    public GameObject targetObject;
    public TMP_Text targetObj_Name;
    public TMP_Text targetObj_Description;


    public Slider sizeSlider;
    public float sizePercentage;
    public float maxSize;
    public float minSize;
    public float currentSize;
//    bool check;

    // Start is called before the first frame update
    void Start()
    {
        stageControllerObj = GameObject.FindGameObjectWithTag("StageController");
        targetObj_Name.text = targetObject.GetComponent<Jellyfish_Speicification>().jellName;
        maxSize = targetObject.GetComponentInChildren<JellyfishClickFeeding>().maxSize;
        minSize = targetObject.GetComponentInChildren<JellyfishClickFeeding>().minSize;

        //        check = false;
    }

    public void deleteTargetObject()
    {
        stageControllerObj.GetComponent<prototypeStageController>().money += targetObject.GetComponent<Jellyfish_Speicification>().sellPrice;
        Destroy(targetObject);
        print("deleteJellyfish");
        Destroy(selfOB);
    }

    private void Update()
    {
        displaySize();
    }

    private void displaySize()
    {
        targetObj_Description.text = "크기:" + targetObject.GetComponentInChildren<JellyfishClickFeeding>().sizePercentage+"%" +"/"+ targetObject.GetComponent<Jellyfish_Speicification>().myStatus;
    }


    //private void Update()
        //{
        //    sizeSlider.GetComponent<Slider>().value = sizePercentage;
        //}


        public void DeleteButtonClicked()
    {
        GameObject popup;
        popup = Instantiate(popUpUIPrefab);
        popup.GetComponent<PopUpUISCnew>().CautionString = targetObject.GetComponent<Jellyfish_Speicification>().jellName + "\n판매금액 : " + targetObject.GetComponent<Jellyfish_Speicification>().sellPrice + "J\n" + "판매하시겠습니까?" ;
        //popup.GetComponent<PopUpUISCnew>().targetCanvas = parentCanvas;
        popup.GetComponent<PopUpUISCnew>().GetMethodfromCaller = deleteTargetObject;
        StartCoroutine(WaitForIt());
        //if (check)
        //{
        //    parentCanvas.SetActive(false);
        //}        
    }


    IEnumerator WaitForIt()
    {
        yield return new WaitForEndOfFrame();
  //      check = true;
    }

}
