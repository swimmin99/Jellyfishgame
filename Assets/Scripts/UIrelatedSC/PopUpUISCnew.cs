using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpUISCnew : MonoBehaviour
{
    //public GameObject targetCanvas;
    public delegate void getMethodfromCaller();
    public getMethodfromCaller GetMethodfromCaller;

    public TMP_Text cautionWarning;
    public string CautionString;
    public TabButton yesButton;
    public TabButton noButton;
    // Start is called before the first frame update

    private void Start()
    {
        cautionWarning.text = CautionString;
    }

    public void delete()
    {
        //targetCanvas.SetActive(true);
        Destroy(gameObject);
    }


    public void featureStart () {
        if (GetMethodfromCaller!=null)
        {
            GetMethodfromCaller();
            print("pop up executed");
        }
    }

}
