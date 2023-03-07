using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JellyfishButtonCS : MonoBehaviour
{
    public GameObject parentCanvas;
    public GameObject popUpUIPrefab;
    public GameObject selfOB;


    public int buttonNumber;
    public GameObject targetObject;
    public TMP_Text targetObj_Name;
    public TMP_Text targetObj_Description;

    bool check;

    // Start is called before the first frame update
    void Start()
    {
        targetObj_Name.text = targetObject.GetComponent<Jellyfish_Speicification>().jellName;
        targetObj_Description.text = "SIZE :" + targetObject.GetComponentInChildren<JellyfishClickFeeding>().addedSize.ToString();
        check = false;
    }

    public void deleteTargetObject()
    {
        Destroy(targetObject);
        print("deleteJellyfish");
        Destroy(selfOB);
    }


    public void DeleteButtonClicked()
    {
        GameObject popup;
        popup = Instantiate(popUpUIPrefab);
        popup.GetComponent<PopUpUISCnew>().targetCanvas = parentCanvas;
        popup.GetComponent<PopUpUISCnew>().GetMethodfromCaller = deleteTargetObject;
        StartCoroutine(WaitForIt());
        if (check)
        {
            parentCanvas.SetActive(false);
        }        
    }


    IEnumerator WaitForIt()
    {
        yield return new WaitForEndOfFrame();
        check = true;
    }

}
