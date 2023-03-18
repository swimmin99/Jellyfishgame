using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class saveTestUISC : MonoBehaviour
{
    public TMP_Text textPrefab;
    public GameObject dataPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void onClick()
    {
        int count = dataPrefab.GetComponent<saveGateway>().entries.Count;
        textPrefab.text = "";
            for (int i = 0; i < count; i++) {
                print(i);
                textPrefab.text += dataPrefab.GetComponent<saveGateway>().entries[i].playerName.ToString() + "/" + dataPrefab.GetComponent<saveGateway>().entries[i].points.ToString();
            }
    }
}
