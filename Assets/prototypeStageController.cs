using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class prototypeStageController : MonoBehaviour
{
    public int money = 100;
    public bool isFeeding;
    public GameObject foodParticle;
    public TMP_Text MoneyGUIObject;
    // Start is called before the first frame update
    void Start()
    {
        isFeeding = false;
        
    }

    // Update is called once per frame
    void Update()
    {
      //  MoneyGUIObject.text = "Money : " + money.ToString();
        if (isFeeding)
        {
            feeding();
        }
    }

    public void feeding()
    {
        if (Input.mousePosition.y < Screen.height - 200f)
        {
            print(Input.mousePosition.y + "/" + Screen.height);
            if (money >= 10)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
                    Instantiate(foodParticle, rayCast.GetPoint(10), Quaternion.identity);
                    money -= 10;
                }
            }
        }
    }


    public void isFeedingOn()
    {
        if (isFeeding == false)
        {
            print("FeedingOn");
            isFeeding = true;
        }
        else {
            print("FeedingOff");
            isFeeding = false;
        }
    }
}
