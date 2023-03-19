using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class inputUISC : MonoBehaviour
{
    //public GameObject targetCanvas;
    public delegate void getMethodfromCaller(string inputString);
    public getMethodfromCaller GetMethodfromCaller;

    public TMP_InputField inputField;

    public string CautionString;


    public GameObject blankWarning;
    public GameObject duplicateWarning;
    // Start is called before the first frame update

    public bool checkNullInput()
    {
        
        if (string.IsNullOrWhiteSpace(inputField.text))
        {
            blankWarning.SetActive(true);
            return true;
        }
        else
        {
            return false;
        }

    }


    public void featureStart()
    {
        duplicateWarning.SetActive(false);
        blankWarning.SetActive(false);

        if (checkNullInput() == false && DuplicateNameCheck() == false)
        {

            if (GetMethodfromCaller != null)
            {
                GetMethodfromCaller(inputField.text);
                print("pop up executed");

                delete();
            }

        }
    }

    public bool DuplicateNameCheck() {

        if (findName(inputField.text) == true)
        {
            duplicateWarning.SetActive(true);
            return true;

        } else
            return false;


    }

    
    
    public void delete()
    {
        //targetCanvas.SetActive(true);
        Destroy(gameObject);
    }

    private bool findName(string name)
    {
        GameObject parentObj = GameObject.FindGameObjectWithTag("JellyfishListController");
        if (parentObj.transform)
        {
            List<GameObject> tag_targets = new List<GameObject>();

            if (FindDescendantsWithName(parentObj.transform, "Targets", tag_targets, name) == true)
                return true;
            else
                return false;

        }
        else
        {
            return false;
        }
    }



    private bool FindDescendantsWithName(Transform parent, string tag, List<GameObject> list, string name)
    {
        bool isFound = false;
        foreach (Transform child in parent)
        {
            if (child.gameObject.tag == "JellyfishTag" && child.gameObject.GetComponent<Jellyfish_Speicification>().jellName == name)
            {
                isFound = true;
            }
        }

        return isFound;
    }


    // Checks if there is anything entered into the input field.
    //void LockInput(InputField input)
    //{
    //    if (input.text.Length > 0)
    //    {
    //        Debug.Log("Text has been entered");
    //    }
    //    else if (input.text.Length == 0)
    //    {
    //        Debug.Log("Main Input Empty");
    //    }
    //}

    //public void Start()
    //{
    //    //Use onSubmit
    //    mainInputField.onSubmit.AddListener(delegate { LockInput(mainInputField); });
    //}


}
