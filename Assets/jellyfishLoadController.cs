using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jellyfishLoadController : MonoBehaviour
{
    public GameObject jellyProductPrefab;
    public GameObject jellyfishController;
    public saveController saver;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void instantiater(List<JellyfishListSave> jflEntries)
    {
        foreach (JellyfishListSave specs in jflEntries) {

            GameObject temp;
            print("loadStarted");
            temp = Instantiate(jellyProductPrefab, jellyfishController.transform);
            temp.transform.position = new Vector3(0, 0, 0);
            temp.GetComponent<Jellyfish_Speicification>().jellName = specs.jellyfishName;
            temp.GetComponent<Jellyfish_Speicification>().originalPrice = specs.originalPrice;
            temp.GetComponent<Jellyfish_Speicification>().myColor1 = new Color(specs.color1_x, specs.color1_y, specs.color1_z, specs.color1_a);
            temp.GetComponent<Jellyfish_Speicification>().myColor2 = new Color(specs.color2_x, specs.color2_y, specs.color2_z, specs.color2_a);

            temp.transform.Find("JLOBJ").GetComponentInChildren<MeshRenderer>().material.SetColor("_Color1", ChangeHDRColorIntensity(new Color(specs.color1_x, specs.color1_y, specs.color1_z, specs.color1_a), 0.5f));
            temp.transform.Find("JLOBJ").GetComponentInChildren<MeshRenderer>().material.SetColor("_Color2", ChangeHDRColorIntensity(new Color(specs.color2_x, specs.color2_y, specs.color2_z, specs.color2_a), 4));

        }
    }




    private const byte k_MaxByteForOverexposedColor = 191; //internal Unity const 

    private Color ChangeHDRColorIntensity(Color subjectColor, float intensityChange)
    {
        // Get color intensity
        float maxColorComponent = subjectColor.maxColorComponent;
        float scaleFactorToGetIntensity = k_MaxByteForOverexposedColor / maxColorComponent;
        float currentIntensity = Mathf.Log(255f / scaleFactorToGetIntensity) / Mathf.Log(2f);

        // Get original color with ZERO intensity
        float currentScaleFactor = Mathf.Pow(2, currentIntensity);
        Color originalColorWithoutIntensity = subjectColor / currentScaleFactor;

        // Add color intensity
        float modifiedIntensity = currentIntensity + intensityChange;

        // Set color intensity
        float newScaleFactor = Mathf.Pow(2, modifiedIntensity);
        Color colorToRetun = originalColorWithoutIntensity * newScaleFactor;

        // Return color
        return colorToRetun;
    }

}
