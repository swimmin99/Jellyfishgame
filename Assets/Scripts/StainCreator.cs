using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StainCreator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 screenPosition = new Vector3 (Random.Range(-1 * Screen.width / 2, Screen.width / 2),
                                              Random.Range(-1 * Screen.height / 2, Screen.height / 2), -0);
        Vector3 objPos = Camera.main.ScreenToWorldPoint(screenPosition);
        objPos.z = -1f;
        transform.position = objPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
