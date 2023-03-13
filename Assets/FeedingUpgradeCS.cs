using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeedingUpgradeCS : MonoBehaviour
{
    //public GameObject myTargetCanvas;
    public int Price;

    public TMP_Text PriceUI;
    public TMP_Text ratioUI;

    public GameObject popUpUIPrefab;
    public GameObject AlertPrefab;


    public bool displayOne;



    private prototypeStageController stageController;
    private GameObject jellyfishController;

    // Start is called before the first frame update
    void Start()
    {

        stageController = GameObject.FindGameObjectWithTag("StageController").GetComponent<prototypeStageController>();
        jellyfishController = GameObject.FindGameObjectWithTag("JellyfishListController");
        PriceUI.text = Price + "J";

    }

    // Update is called once per frame
    void Update()
    {
        ratioUI.text = (((int)stageController.GetComponent<prototypeStageController>().foodRatio).ToString()) + "X";
    }

    public delegate void feature();

    public void instantiateProduct()
    {
        print("printDetected");
        if (stageController.money >= Price)
        {
            print("buy successed");
            stageController.money -= Price;
            stageController.GetComponent<prototypeStageController>().foodRatio *= 2;
        }
        else
        {
            Debug.Log("Insufficient Money");
            Instantiate(AlertPrefab).GetComponent<AlertCS>().CautionString = "젤리가 부족합니다.";
        }
    }


    public void BuyButtonClicked()
    {
        GameObject popup;
        popup = Instantiate(popUpUIPrefab);
        popup.GetComponent<PopUpUISCnew>().CautionString = "구매하시겠습니까?";
        //        popup.GetComponent<PopUpUISCnew>().targetCanvas = myTargetCanvas;
        popup.GetComponent<PopUpUISCnew>().GetMethodfromCaller = instantiateProduct;
        //myTargetCanvas.SetActive(false);
    }



    private const byte k_MaxByteForOverexposedColor = 191; //internal Unity const 

    private Color ChangeHDRColorIntensity(Color subjectColor, float intensityChange)
    {
        // Get color intensity
        float maxColorComponent = subjectColor.maxColorComponent;
        float scaleFactorToGetIntensity = k_MaxByteForOverexposedColor / maxColorComponent;
        float currentIntensity = Mathf.Log(255f / scaleFactorToGetIntensity) / Mathf.Log(2f);

        // Get original color with ZERO intensity
        float currentScaleFactor = Mathf.Pow(2, currentIntensity);
        Color originalColorWithoutIntensity = subjectColor / currentScaleFactor;

        // Add color intensity
        float modifiedIntensity = currentIntensity + intensityChange;

        // Set color intensity
        float newScaleFactor = Mathf.Pow(2, modifiedIntensity);
        Color colorToRetun = originalColorWithoutIntensity * newScaleFactor;

        // Return color
        return colorToRetun;
    }




}
