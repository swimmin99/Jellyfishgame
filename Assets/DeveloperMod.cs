using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperMod : MonoBehaviour
{
    public prototypeStageController stageController;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClick()
    {
        stageController.money += 1000;
    }

}
