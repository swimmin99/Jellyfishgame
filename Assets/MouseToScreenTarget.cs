using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseToScreenTarget : MonoBehaviour
{
    JellyfishStatusHygine isCleaningComponenet;
    private Renderer targetRenderer;
    public Color MouseOnColor1;
    public Color MouseOffColor2;
    void Start()
    {
        targetRenderer = GetComponent<Renderer>();
        isCleaningComponenet = GameObject.FindGameObjectWithTag("Jellyfish").GetComponent<JellyfishStatusHygine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if(isCleaningComponenet.isCleaning)
        targetRenderer.material.color = MouseOnColor1;
    }

    private void OnMouseExit()
    {
        if (isCleaningComponenet.isCleaning)
        targetRenderer.material.color = MouseOffColor2;
    }

    private void OnMouseDown()
    {
        if (isCleaningComponenet.isCleaning)
        {
            if (Input.GetMouseButtonDown(0))
            {
                print("click detected");
                Destroy(gameObject);
            }
        }
    }


}
