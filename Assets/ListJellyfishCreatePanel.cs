using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListJellyfishCreatePanel : MonoBehaviour
{
    public GameObject prefab;
    public GameObject created;
    // Start is called before the first frame update
    void Start()
    {
        created = Instantiate(prefab, transform);
        created.GetComponent<JellyfishListUI>().parentObj = GameObject.FindGameObjectWithTag("JellyfishListController").transform;
        created.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
