using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jellyfishListRefresher : MonoBehaviour
{
    public Transform parentObj;

    public float timer;
    private float limitTime = 10f;
    public saveController savingComponent;

    // Start is called before the first frame update
    void Start()
    {
        savingComponent = GetComponent<saveController>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > limitTime)
        {
            SaveMethod(refresher());
            timer = 0f;
        }


    }

    public List<GameObject> refresher()
    {
        if (parentObj.transform)
        {
            List<GameObject> tag_targets = new List<GameObject>();
            AddDescendantsWithTag(parentObj, "Targets", tag_targets);

            return tag_targets;

        }
        return null;
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


    public void SaveMethod(List<GameObject>list)
    {
        List<JellyfishListSave> temp = new List<JellyfishListSave>();
        print(list.Count);
        int i = 0;
        foreach(GameObject go in list)
        {
            print("herer>");
            temp.Add(
                new JellyfishListSave(
                    go.GetComponent<Jellyfish_Speicification>().jellName,
                    go.GetComponentInChildren<JellyfishClickFeeding>().addedSize,
                    go.GetComponent<Jellyfish_Speicification>().originalPrice,
                    go.GetComponent<Jellyfish_Speicification>().myColor1.r, go.GetComponent<Jellyfish_Speicification>().myColor1.g, go.GetComponent<Jellyfish_Speicification>().myColor1.b, go.GetComponent<Jellyfish_Speicification>().myColor1.a,
                    go.GetComponent<Jellyfish_Speicification>().myColor2.r, go.GetComponent<Jellyfish_Speicification>().myColor2.g, go.GetComponent<Jellyfish_Speicification>().myColor2.b, go.GetComponent<Jellyfish_Speicification>().myColor1.a
            ));
            print("workshere");
            i++;
        }
        i = 0;

        savingComponent.overwriteToList(temp);


    }
}
