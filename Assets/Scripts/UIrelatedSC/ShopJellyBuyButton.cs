using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopJellyBuyButton : MonoBehaviour
{
    //public GameObject myTargetCanvas;
    public int Price;

    public TMP_Text PriceUI;
    public GameObject popUpUIPrefab;
    public GameObject jellyProductPrefab;
    public GameObject AlertPrefab;

    public Color color1;
    public Color color2;


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
        
    }

    public delegate void feature();

    public void instantiateProduct()
    {
        print("printDetected");
        if (stageController.money >= Price)
        {
            GameObject temp;
            print("buy successed");
            stageController.money -= Price;
            temp = Instantiate(jellyProductPrefab, jellyfishController.transform);
            temp.transform.position = new Vector3(0, 0, 0);
            temp.GetComponent<Jellyfish_Speicification>().callInputString();
            temp.GetComponent<Jellyfish_Speicification>().originalPrice = Price;

            temp.transform.Find("JLOBJ").GetComponentInChildren<MeshRenderer>().material.SetColor("_Color1", ChangeHDRColorIntensity(color1, 0.5f));
            temp.transform.Find("JLOBJ").GetComponentInChildren<MeshRenderer>().material.SetColor("_Color2", ChangeHDRColorIntensity(color2, 4));
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
