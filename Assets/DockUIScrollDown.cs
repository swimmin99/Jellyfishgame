using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockUIScrollDown : MonoBehaviour
{
    public bool isDown;
    private bool goingUp;
    private bool goingDown;
    RectTransform rectUItransform;
    // Start is called before the first frame update
    float pastTime;
    float targetTime;


    void Start()
    {
        goingUp = false;
        rectUItransform = GetComponent<RectTransform>();
        isDown = true;
        pastTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (goingUp)
        {
            print("Up");
            pastTime += Time.deltaTime;

            rectUItransform.anchoredPosition = new Vector2(rectUItransform.anchoredPosition.x, rectUItransform.anchoredPosition.y + 14*Mathf.Sin(pastTime));
            if (Mathf.Sin(pastTime) >= 0.5)
            {
                pastTime = 0f;
                goingUp = false;
                isDown = false;
            }
        }


        if (goingDown)
        {
            print("Down");
            pastTime += Time.deltaTime;

            rectUItransform.anchoredPosition = new Vector2(rectUItransform.anchoredPosition.x, rectUItransform.anchoredPosition.y - 14 * Mathf.Sin(pastTime));
            if (Mathf.Sin(pastTime) >= 0.5)
            {
                pastTime = 0f;
                goingDown = false;
                isDown = true;
            }
        }
    }

    public void OnClickUI()
    {
        if (isDown)
        {
            goingUp = true;
        }
        else
        {
            goingDown = true;
        }

    }
}
