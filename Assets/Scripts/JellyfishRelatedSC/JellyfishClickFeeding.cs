using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishClickFeeding : MonoBehaviour
{
    private Renderer targetRenderer;
    public Color MouseOnColor1;
    public Color MouseOffColor2;
    public GameObject food;
    public float clickAmount;
    public float addedSize;
    public float minSize = 1f;
    public float maxSize = 3f;


    public bool resizing;
    void Start()
    {
        //resizing = false;
        clickAmount = 1f;
        targetRenderer = GetComponent<Renderer>();
        food.GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {

        addedSize = minSize + Mathf.Log(clickAmount);
        transform.localScale = new Vector3
        (
           addedSize, addedSize, addedSize
        );
    }


    private void OnMouseDown()
    {
        if (resizing == true)
        {
            LeanTween.cancel(gameObject);
            resizing = false;
        }

        if (resizing == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                resizing = true;

                
                    LeanTween.scale(gameObject, new Vector3(transform.localScale.x * 1.1f, transform.localScale.y * 1.1f, transform.localScale.z * 1.1f), 0.5f).setEase(LeanTweenType.punch).setOnComplete(delegate ()
                    {
                        resizing = false;
                    });
                if (addedSize >= minSize && addedSize <= maxSize)
                {
                    Instantiate(food, transform.position, transform.rotation);
                    //if (food.GetComponent<ParticleSystem>().isStopped)
                    //    food.GetComponent<ParticleSystem>().Play();
                    //else
                    //{
                    //    food.GetComponent<ParticleSystem>().Play();

                    //}
                    clickAmount += 0.001f / transform.localScale.x;
                }
                

            }
        }


        
    }
}
