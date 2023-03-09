using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JellyfishListUI : MonoBehaviour
{
    public Transform parentObj;
    public GameObject buttonTemplate;

    public GameObject POPUPKeepingUI;
    public GameObject POPUPdisablingUI;

    GameObject g;
    static int selectedButtonNum;
    // Start is called before the first frame update

    void OnEnable()
    {

        print("hello");
        if (parentObj.transform)
        {
            List<GameObject> tag_targets = new List<GameObject>();
            AddDescendantsWithTag(parentObj, "Targets", tag_targets);
            drawButtons(tag_targets);
            foreach (GameObject go in tag_targets)
            {
                print(go.name);
            }
        }
    }

    void OnDisable()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
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
