using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishListUI : MonoBehaviour
{
    public List<GameObject> tag_targets = new List<GameObject>();
    public Transform parentObj;
    public GameObject buttonTemplate;
    GameObject g;
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
            AddDescendantsWithTag(child, tag, list);
        }
    }

    void Start()
    {
        print("hello");
        AddDescendantsWithTag(parentObj, "Targets", tag_targets);
        drawButtons();
    }


    void drawButtons()
    {
        foreach(GameObject go in tag_targets)
        {
            print("InstancingButtons");
            Instantiate(buttonTemplate, transform).GetComponent<JellyfishButtonCS>().targetObject = go;
        }
    }

}
