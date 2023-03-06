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

    void Start()
    {
        clickAmount = 2f;
        targetRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

        addedSize = 0.5f + Mathf.Log(clickAmount);
        transform.localScale = new Vector3
        (
           addedSize, addedSize, addedSize
        );
    }

    private void OnMouseDown()
    {
       
            if (Input.GetMouseButtonDown(0))
            {
            LeanTween.scale(gameObject, new Vector3(transform.localScale.x *1.1f, transform.localScale.y * 1.1f, transform.localScale.z * 1.1f), 1f).setEase(LeanTweenType.punch);
            print("Feeding click detected");
                Instantiate(food, transform.position, transform.rotation);
                clickAmount += 0.001f/transform.localScale.x;
            }

    }
}
