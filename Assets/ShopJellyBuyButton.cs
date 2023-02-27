using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopJellyBuyButton : MonoBehaviour
{
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

    public void BuyButtonClicked()
    {
        print("printDetected");
        if (stageController.money >= 20)
        {
            print("buy successed");
            stageController.money -= 20;
            Instantiate(jellyProductPrefab, jellyfishController.transform).transform.position = new Vector3(0,0,0);
        }
        else
        {
            Debug.Log("Insufficient Money");
        }
    }
}
