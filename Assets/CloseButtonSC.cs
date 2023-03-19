using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButtonSC : MonoBehaviour
{
    public jellyfishListRefresher saverPrefab;
    public GameObject popUpPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Onclick()
    {
       

    }

    void closeGame()
    {
        saverPrefab.Saver();
        print("closing the application");
        Application.Quit();
    }

    public void BuyButtonClicked()
    {
        GameObject popup;
        popup = Instantiate(popUpPrefab);
        popup.GetComponent<PopUpUISCnew>().CautionString = "종료하시겠습니까?";
        //        popup.GetComponent<PopUpUISCnew>().targetCanvas = myTargetCanvas;
        popup.GetComponent<PopUpUISCnew>().GetMethodfromCaller = closeGame;
        //myTargetCanvas.SetActive(false);
    }
}
