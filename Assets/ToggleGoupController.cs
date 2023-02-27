using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGoupController : MonoBehaviour
{
    ToggleGroup jellyfishLinkContentGroup;
    Toggle myToggle;
    GameObject ThisTargetObject;
    GameObject targetChild;
    [SerializeField]public bool childGUIOn;

    // Start is called before the first frame update
    void Start()
    {
        childGUIOn = false;
        ThisTargetObject = GetComponentInParent<JellyfishButtonCS>().targetObject;

        foreach (Transform transform in ThisTargetObject.transform)
        {
            if (transform.CompareTag("JellyfishUI"))
            {
                print("foundChild");
                targetChild = transform.gameObject;
                break;
            }
        }

        jellyfishLinkContentGroup = GameObject.FindGameObjectWithTag("JellyfishListContent").GetComponent<ToggleGroup>(); ;
        myToggle = GetComponent<Toggle>();
        myToggle.group = jellyfishLinkContentGroup;
    }

    private void Update()
    {
   if( myToggle.isOn == true)
        {
            targetChild.SetActive(true);
        } else
        {
            targetChild.SetActive(false);

        }
    }
    // Update is called once per frame

    private void OnDisable()
    {
        targetChild.SetActive(false);
    }
}
