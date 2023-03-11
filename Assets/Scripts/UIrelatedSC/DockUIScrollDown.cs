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
    float moveSize;
    void Start()
    {
        goingUp = false;
        isDown = true;
        //pastTime = 0f;
        //moveSize = 700;
        rectUItransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (goingUp)
        //{
        //    print("Up");
        //    //pastTime += Time.deltaTime;
        //    LeanTween.moveLocalY(gameObject, rectUItransform.localPosition.y - 15f, 20f);
        //    //rectUItransform.anchoredPosition = new Vector2(rectUItransform.anchoredPosition.x, ScreenEnd.y);
        //    //if (Mathf.Sin(pastTime) >= 0.5)
        //    //{
        //    //    pastTime = 0f;
        //    //    goingUp = false;
        //    //    isDown = false;
        //    //}
        //}


        //if (goingDown)
        //{
        //    print("Down");
        //    pastTime += Time.deltaTime;

        //    rectUItransform.anchoredPosition = new Vector2(rectUItransform.anchoredPosition.x, rectUItransform.anchoredPosition.y - moveSize * Mathf.Sin(pastTime));
        //    if (Mathf.Sin(pastTime) >= 0.5)
        //    {
        //        pastTime = 0f;
        //        goingDown = false;
        //        isDown = true;
        //    }
        //}
    }

    public void OnClickUI()
    {
        if (isDown == true && goingUp == false && goingDown == false)
        {
            goingUp = true;
            LeanTween.moveLocalY(gameObject, rectUItransform.localPosition.y - 200f, 0.5f).setEase(LeanTweenType.easeOutSine).setOnComplete(isUpFalse);
        }
        else if (isDown == false && goingUp == false && goingDown == false)
        {
            goingDown = true;
            LeanTween.moveLocalY(gameObject, rectUItransform.localPosition.y + 200f, 0.5f).setEase(LeanTweenType.easeOutSine).setOnComplete(isDownTrue);
        }
    }

    public void isUpFalse()
    {
        isDown = false;
        goingUp = false;
    }

    public void isDownTrue()
    {
        isDown = true;
        goingDown = false;
    }
}
