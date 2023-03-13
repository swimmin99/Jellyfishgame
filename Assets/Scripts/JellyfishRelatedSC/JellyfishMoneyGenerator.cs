using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishMoneyGenerator : MonoBehaviour
{
    float timePast;
    public float generationTerm = 20f;
    public Material moneyMaterial;
    public int myMinimumMoney= 10;

    public GameObject MoneyPrefabs;
    private GameObject jellyfishContainer;
    JellyfishStatusHunger hungerComponenet;
    JellyfishStatusHygine hygineComponent;

    private float feedingRatioAddedSize;

    // Start is called before the first frame update
    void Start()
    {
        moneyMaterial = GetComponent<MeshRenderer>().material;
        hungerComponenet = GetComponent<JellyfishStatusHunger>();
        hygineComponent = GetComponent<JellyfishStatusHygine>();
        jellyfishContainer = GameObject.FindGameObjectWithTag("JellyfishListController");
        timePast = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        feedingRatioAddedSize = (int)Math.Ceiling((MathF.Log10(GetComponent<JellyfishClickFeeding>().sizePercentage)));


        timePast += Time.deltaTime;
        if(timePast > generationTerm)
        {
            GameObject temp;
            temp = Instantiate(MoneyPrefabs, jellyfishContainer.transform);
            temp.GetComponentInChildren<moenyCS>().addedMoneyRatio = (int)(feedingRatioAddedSize<1?1:feedingRatioAddedSize);
            temp.GetComponentInChildren<moenyCS>().minimumMoney = myMinimumMoney;


            temp.transform.transform.position = transform.position;
            temp.transform.rotation = transform.rotation;
            temp.GetComponentInChildren<moenyCS>().myMaterial = moneyMaterial;
            timePast = 0f;
        }
    }
}
