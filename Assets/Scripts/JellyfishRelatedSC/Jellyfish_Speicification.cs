using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish_Speicification : MonoBehaviour
{
    public string jellName;
    public string jeliDescription;
    public GameObject keyboardInputPrefab;
    // Start is called before the first frame update
    private inputUISC inputComponenet;
    public int sellPrice;
    public int originalPrice;

    public Color myColor1;
    public Color myColor2;

    public void callInputString()
    {
        Instantiate(keyboardInputPrefab).GetComponent<inputUISC>().GetMethodfromCaller = changeName;


    }

    private void Start()
    {
        
    }


    public void changeName(string inputString)
    {
        jellName = inputString;

    }

    // Update is called once per frame
    void Update()
    {
        sellPrice = originalPrice + (int)(Mathf.Floor((gameObject.transform.Find("JLOBJ").transform.Find("JLFeature").GetComponent<JellyfishClickFeeding>().addedSize)/10))*10;
    }
}