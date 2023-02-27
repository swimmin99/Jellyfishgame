using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JellyfishButtonCS : MonoBehaviour
{
    public int buttonNumber;
    public GameObject targetObject;
    public TMP_Text targetObj_Name;
    public TMP_Text targetObj_Description;
    // Start is called before the first frame update
    void Start()
    {
        targetObj_Name.text = targetObject.GetComponent<Jellyfish_Speicification>().jellName;
        targetObj_Description.text = "SIZE :" + targetObject.GetComponentInChildren<JellyfishClickFeeding>().addedSize.ToString();
    }

    public void deleteTargetObject()
    {
        Destroy(targetObject);
        Destroy(gameObject);
    }

}
