using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopJellyBuyButton : MonoBehaviour
{
    public GameObject parentCanvas;
    public GameObject popUpUIPrefab;
    public GameObject panelUI;
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


    public void instantiateProduct()
    {
        print("printDetected");
        if (stageController.money >= 20)
        {
            print("buy successed");
            stageController.money -= 20;
            Instantiate(jellyProductPrefab, jellyfishController.transform).transform.position = new Vector3(0, 0, 0);
        }
        else
        {
            Debug.Log("Insufficient Money");
        }
    }

    public void panelSetActive()
    {
        panelUI.SetActive(true);
    }

    public void panelDisabled()
    {
        panelUI.SetActive(false);
    }
    public void BuyButtonClicked()
    {
        GameObject popup;
        popup = Instantiate(popUpUIPrefab, parentCanvas.transform);
        popup.GetComponent<PopUpUIScript>().cautionString = "Are you sure?";
        //popup.transform.Find("PopUpButtonGroup").transform.Find("YesButton").GetComponent<Button>().onClick.AddListener(delegate { instantiateProduct(); });
        //popup.transform.Find("PopUpButtonGroup").transform.Find("YesButton").GetComponent<Button>().onClick.AddListener(delegate { panelSetActive(); });
        //popup.transform.Find("PopUpButtonGroup").transform.Find("NoButton").GetComponent<Button>().onClick.AddListener(delegate { panelSetActive(); });
        panelDisabled();
    }
}
