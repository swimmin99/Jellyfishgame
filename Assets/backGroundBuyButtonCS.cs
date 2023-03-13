using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGroundBuyButtonCS : MonoBehaviour
{
    private int GlobalPrice;
    private bool canBuy;

    public int backGroundNum;
    prototypeStageController stageController;
    public GameObject AlertPrefab;
    public GameObject popUpUIPrefab;
    Color globalColor;

    Color GetHexaToColor(string hexacode) {
        Color myColor;
        ColorUtility.TryParseHtmlString(hexacode, out myColor);

        return myColor;
    }

    

    void getSettingsForColor(int myPrice, Color myColor) {
        bool Purchased = false;
        GlobalPrice = myPrice;
        globalColor = myColor;
        BuyButtonClicked();
    }

    void settingFogColor()
    {
        print("bought");
        RenderSettings.fogColor = globalColor;
        RenderSettings.fog = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        canBuy = false;
        stageController = GameObject.FindGameObjectWithTag("StageController").GetComponent<prototypeStageController>();
    }

    // Update is called once per frame
    void Update()
    {
        print(RenderSettings.fogColor);
    }

    public void onClickBuy()
    {
        switch (backGroundNum) {
            case 1: getSettingsForColor(10, GetHexaToColor("#181C65"));print(1); break;
            case 2: getSettingsForColor(10, Color.blue); print(2); break;
            case 3: getSettingsForColor(10, GetHexaToColor("#612B36")); print(3); break;
            case 4: getSettingsForColor(10, Color.red); print(4); break;
            case 5: getSettingsForColor(10, Color.green); print(5); break;
            case 6: getSettingsForColor(10, Color.black); print(6); break;
            case 7: getSettingsForColor(10, Color.white); print(7); break;
        }
    }


    public delegate void feature();

    public void instantiateProduct()
    {
        print("printDetected");
        if (stageController.money >= GlobalPrice)
        {
            print("buy successed");
            settingFogColor();
            stageController.money -= GlobalPrice;
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
}
