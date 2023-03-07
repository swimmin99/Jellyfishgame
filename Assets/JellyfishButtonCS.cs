using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JellyfishButtonCS : MonoBehaviour
{
    public GameObject parentCanvas;
    public GameObject popUpUIPrefab;
    public GameObject panelUI;

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
        print("deleteJellyfish");
        Destroy(targetObject);
        Destroy(gameObject);
    }


    public void panelSetActive()
    {
        panelUI.SetActive(true);
    }

    public void panelDisabled()
    {
        panelUI.SetActive(false);
    }

    public void DeleteButtonClicked()
    {
        GameObject popup;
        popup = Instantiate(popUpUIPrefab, parentCanvas.transform);
        popup.GetComponent<PopUpUIScript>().cautionString = "Are you sure you sell the jellyfish?";

        //popup.transform.Find("PopUpButtonGroup").transform.Find("YesButton").GetComponent<Button>().onClick.AddListener(delegate { panelSetActive(); });
        popup.transform.Find("PopUpButtonGroup").transform.Find("YesButton").GetComponent<Button>().onClick.AddListener(delegate { deleteTargetObject(); });
        //panelDisabled();
    }

}
