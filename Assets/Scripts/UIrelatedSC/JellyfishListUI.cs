using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class JellyfishListUI : MonoBehaviour
{
    public Transform parentObj;
    public GameObject buttonTemplate;
    public jellyfishListRefresher refresher;

    public GameObject POPUPKeepingUI;
    public GameObject POPUPdisablingUI;
    public GameObject blankWarningUI;
    public Toggle listToggle;


    GameObject g;
    static int selectedButtonNum;
    // Start is called before the first frame update

    void OnEnable()
    {
        blankWarningUI.SetActive(false);
       
        List<GameObject> tag_targets = new List<GameObject>();

        tag_targets = refresher.refresher();

        if (tag_targets == null)
        {
            blankWarningUI.SetActive(true);
        }
        else
        {

            drawButtons(tag_targets);
            foreach (GameObject go in tag_targets)
            {
                print(go.name);
            }
        }


        print("hello");
        
    }

    void OnDisable()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
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
