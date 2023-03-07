using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopJellyBuyButton : MonoBehaviour
{
    public GameObject myTargetCanvas;
    public GameObject popUpUIPrefab;
    public GameObject jellyProductPrefab;
    private prototypeStageController stageController;
    private GameObject jellyfishController;

    // Start is called before the first frame update
    void Start()
    {
        stageController = GameObject.FindGameObjectWithTag("StageController").GetComponent<prototypeStageController>();
        jellyfishController = GameObject.FindGameObjectWithTag("JellyfishListController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public delegate void feature();

    public void instantiateProduct()
    {
        print("printDetected");
        if (stageController.money >= 10)
        {
            print("buy successed");
            stageController.money -= 10;
            Instantiate(jellyProductPrefab, jellyfishController.transform).transform.position = new Vector3(0, 0, 0);
        }
        else
        {
            Debug.Log("Insufficient Money");
        }
    }

   
    public void BuyButtonClicked()
    {
        GameObject popup;
        popup = Instantiate(popUpUIPrefab);
        popup.GetComponent<PopUpUISCnew>().targetCanvas = myTargetCanvas;
        popup.GetComponent<PopUpUISCnew>().GetMethodfromCaller = instantiateProduct;
        myTargetCanvas.SetActive(false);
    }
}
