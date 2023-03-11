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
    public TabButton yesButton;
    public TabButton noButton;

    // Start is called before the first frame update

    public void featureStart()
    {
        if (GetMethodfromCaller != null)
        {
            GetMethodfromCaller(inputField.text);
            print("pop up executed");
        }
    }

    
    
    public void delete()
    {
        //targetCanvas.SetActive(true);
        Destroy(gameObject);
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
