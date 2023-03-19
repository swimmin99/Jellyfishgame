using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlertCS : MonoBehaviour
{
    //public GameObject targetCanvas;

    public TMP_Text cautionWarning;

    public string CautionString;
    //public TabButton yesButton;

    private void Start()
    {
        cautionWarning.text = CautionString;
    }

    public void delete()
    {
        //targetCanvas.SetActive(true);
        Destroy(gameObject);
    }





}
