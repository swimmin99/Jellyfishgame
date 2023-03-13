using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class prototypeStageController : MonoBehaviour
{
    public int money = 100;
    public bool isFeeding;
    public GameObject foodParticle;
    public TMP_Text MoneyGUIObject;


    public GameObject wallPrefab;
    public GameObject waterPrefab;

    public Camera mymainCamera;
    Vector3 screenPosition;
    public float movingLimitX;
    public float movingLimitY;
    public float movingLimitZ;
    public float localScaleZ;

    public GameObject mapObjectPrefab;
    public Material mapFloorMaterial;

    public float foodRatio;

    private void Awake()
    {
        screenPosition = mymainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Vector3.Distance(transform.position, mymainCamera.transform.position)));
        movingLimitX = screenPosition.x;
        movingLimitY = screenPosition.y;
        movingLimitZ = (transform.position.z - mymainCamera.transform.position.z) / 4;
        localScaleZ = screenPosition.z;


        GameObject ceiling = Instantiate(wallPrefab, gameObject.transform);
        ceiling.transform.position = new Vector3(0, movingLimitY, localScaleZ);
        ceiling.transform.localScale = new Vector3(15, 1, 15);

        GameObject floor = Instantiate(wallPrefab, gameObject.transform);
        floor.transform.position = new Vector3(0, -movingLimitY, localScaleZ);
        floor.transform.localScale = new Vector3(15, 1, 15);
        floor.GetComponent<MeshRenderer>().material = mapFloorMaterial;

        GameObject leftWall = Instantiate(wallPrefab, gameObject.transform);
        leftWall.transform.position = new Vector3(-2 * movingLimitX, 0, localScaleZ);
        leftWall.transform.localScale = new Vector3(0.5f, 15, 15);


        GameObject rightWall = Instantiate(wallPrefab, gameObject.transform);
        rightWall.transform.position = new Vector3(2 * movingLimitX, 0, localScaleZ);
        rightWall.transform.localScale = new Vector3(0.5f, 15, 15);

        GameObject backWall = Instantiate(wallPrefab, gameObject.transform);
        backWall.transform.position = new Vector3(0, 0, Vector3.Distance(Vector3.zero, mymainCamera.transform.position) / 2);
        backWall.transform.localScale = new Vector3(15, 15, 1);

        GameObject waterLine = Instantiate(waterPrefab, gameObject.transform);
        waterLine.transform.position = new Vector3(0, movingLimitY * 0.85f, localScaleZ);
        ceiling.transform.localScale = new Vector3(15, 1, 15);

        mymainCamera.transform.position = new Vector3(mymainCamera.transform.position.x, mymainCamera.transform.position.y, mymainCamera.transform.position.z + mymainCamera.transform.position.z / 2);
        mymainCamera.fieldOfView = 50;




        GameObject mapObject = Instantiate(mapObjectPrefab, gameObject.transform);
        mapObject.transform.localScale = new Vector3(screenPosition.x * 2f, screenPosition.y, movingLimitZ);
        mapObject.transform.position = new Vector3(0, floor.transform.position.y + mapObject.transform.localScale.y/2f, backWall.transform.position.z - 1);

    }


    // Start is called before the first frame update
    void Start()
    {
        foodRatio = 1f;
        isFeeding = false;

    }

    // Update is called once per frame
    void Update()
    {
        MoneyGUIObject.text = money.ToString();
        if (isFeeding)
        {
            feeding();
        }
    }

    public void feeding()
    {
        if (Input.mousePosition.y < Screen.height - 200f)
        {
            print(Input.mousePosition.y + "/" + Screen.height);
            if (money >= 10)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
                    Instantiate(foodParticle, rayCast.GetPoint(10), Quaternion.identity);
                    money -= 10;
                }
            }
        }
    }


    public void isFeedingOn()
    {
        if (isFeeding == false)
        {
            print("FeedingOn");
            isFeeding = true;
        }
        else
        {
            print("FeedingOff");
            isFeeding = false;
        }
    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(new Vector3(-1 * movingLimitX, movingLimitY, movingLimitZ), Vector3.one);
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(new Vector3(movingLimitX, movingLimitY, movingLimitZ), Vector3.one);
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(new Vector3(-1 * movingLimitX, movingLimitY, -movingLimitZ), Vector3.one);
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(new Vector3(movingLimitX, movingLimitY, -movingLimitZ), Vector3.one);
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(new Vector3(-1 * movingLimitX, -movingLimitY, movingLimitZ), Vector3.one);
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(new Vector3(movingLimitX, -movingLimitY, movingLimitZ), Vector3.one);
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(new Vector3(-1 * movingLimitX, -movingLimitY, -movingLimitZ), Vector3.one);
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(new Vector3(movingLimitX, -movingLimitY, -movingLimitZ), Vector3.one);

        Gizmos.color = Color.green;
        Gizmos.DrawCube(screenPosition, Vector3.one);
    }
}