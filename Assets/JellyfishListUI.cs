using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JellyfishListUI : MonoBehaviour
{
    public Transform parentObj;
    public GameObject buttonTemplate;
    GameObject g;
    static int selectedButtonNum;
    // Start is called before the first frame update

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


    void OnEnable()
    {
        print("hello");
        List<GameObject> tag_targets = new List<GameObject>();
        AddDescendantsWithTag(parentObj, "Targets", tag_targets);
        drawButtons(tag_targets);
        foreach (GameObject go in tag_targets)
        {
            print(go.name);
        }
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
                print("InstancingButtons");
                Instantiate(buttonTemplate, transform).GetComponent<JellyfishButtonCS>().targetObject = go;
                    
        }
        }

    }
