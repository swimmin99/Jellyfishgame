using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRandomizationCS : MonoBehaviour
{
    private string myDate;

    private void Awake()
    {
        if (newDay() == true)
            setTwoNewColors();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setTwoNewColors() {
        GetComponent<ShopJellyBuyButton>().color1 = Random.ColorHSV();
        GetComponent<ShopJellyBuyButton>().color2 = Random.ColorHSV();
    }


    private bool newDay() {

        if (System.DateTime.Now.ToString() == myDate)
            return false;
        else
            return true;
    }
}
