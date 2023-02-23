using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JellyfishStatusHunger : MonoBehaviour
{
    public float maxHungerValue = 500;
    private float hunger;
    
    public float intimacy;


    private Renderer jellyfishRenderer;
    public TMP_Text hungerRateTextObject;
    public TMP_Text hungerStatusTextObject;
    public float Hunger
    {
        get { return hunger; }
        set { if (value > 0) { hunger = value; } else { hunger = 0; } }
    }
    public float hungerRate = 0.5f;
    public bool isHungry = false;
    // Start is called before the first frame update


    void Start()
    {
        intimacy = 0f;
        jellyfishRenderer = GetComponent<Renderer>();
        hunger = maxHungerValue;
       
    }

    // Update is called once per frame
    void Update()
    {
        hungerRateTextObject.text = "Hunger Rate : " + hunger.ToString();
        hungerStatusTextObject.text = "Hunger State : " + isHungry.ToString();
        hunger -= Time.deltaTime * hungerRate;
        hunger = Mathf.Clamp(hunger, 0f, maxHungerValue);


        if (hunger < maxHungerValue / 2)
        {
            isHungry = true;
        }
        if (hunger >= maxHungerValue / 2)
        {
            isHungry = false;
        }


    }


    public void foodIntake(float value)
    {
        hunger += value;
        if (hunger > maxHungerValue)
        {
            hunger = maxHungerValue;
        }
    }

}
