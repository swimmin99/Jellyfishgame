using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class JellyfishButtonCS : MonoBehaviour
{
    public GameObject targetObject;
    public TMP_Text targetObj_Name;
    public TMP_Text targetObj_Description;

    // Start is called before the first frame update
    void Start()
    {
        targetObj_Name.text = targetObject.GetComponent<Jellyfish_Speicification>().jellName;
        targetObj_Description.text = targetObject.GetComponent<Jellyfish_Speicification>().jeliDescription;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
