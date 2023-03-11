using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeStageCleaningController : MonoBehaviour
{

    public bool isCleaning;


    private void Start()
    {
        isCleaning = false;
    }

    public void isCleaningChange()
    {
        if (isCleaning == true)
            isCleaning = false;
        else if (isCleaning == false)
        {
            isCleaning = true;
        }

    }

}
