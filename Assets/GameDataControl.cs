using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataControl : MonoBehaviour
{
    float saveTime = 10f;
    float timer;


    GameObject jellyfishList;
    public Transform parentObj;


    int saveMoney;

    int jellyFishListSize;
    string[] jellyfishName;


    float[] jellyfishAddedSize;

    float[] jellyfishColorR;
    float[] jellyfishColorG;
    float[] jellyfishColorB;
    float[] jellyfishColorA;

    int[] backgroundIsBought;
    float backgroundColorR;
    float backgroundColorG;
    float backgroundColorB;
    float backgroundColorA;


    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= saveTime)
        {


        }



    }

    private void getJellyfishList()
    {
        if (parentObj.transform)
        {
            int index = 0;
            List<GameObject> tag_targets = new List<GameObject>();
            AddDescendantsWithTag(parentObj, "Targets", tag_targets);
            {
                foreach (GameObject go in tag_targets)
                {
                    jellyfishAddedSize[index++] = go.transform.Find("JLOBJ").GetComponentInChildren<JellyfishClickFeeding>().addedSize;
                }
            }
        }

    }



    private void AddDescendantsWithTag(Transform parent, string tag, List<GameObject> list)
    {
        foreach (Transform child in parent)
        {
            print("gettingChildFromtheOBJ");
            if (child.gameObject.tag == "JellyfishTag")
            {
                list.Add(child.gameObject);
            }
            //AddDescendantsWithTag(child, tag, list);
        }
    }




    void drawButtons(List<GameObject> list)
    {
        foreach (GameObject go in list)
        {
            GameObject GOtemp;
            print("InstancingButtons");
            GOtemp = Instantiate(buttonTemplate, transform);
            GOtemp.GetComponent<JellyfishButtonCS>().targetObject = go;
            //                GOtemp.GetComponent<JellyfishButtonCS>().GetComponent<JellyfishButtonCS>().parentCanvas = POPUPKeepingUI;

        }
    }
}
