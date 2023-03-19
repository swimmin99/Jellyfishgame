using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSC : MonoBehaviour
{
    public prototypeStageController stageController;
    public int tutorialStep;
    GameObject temp;
    public GameObject alert;

    // Start is called before the first frame update
    void Start()
    {
        temp = null;
        tutorialStep = 0;


        
    }

    void display(string a)
    {
        if (temp == null)
        {
            temp = Instantiate(alert, transform);
            temp.GetComponent<AlertCS>().CautionString = a;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (temp == null)
            tutorialStep++;
        switch (tutorialStep)
        {
            case 1: display("환영합니다!"); break;
            case 2: display("해파리를 분양받기 위해 상점 탭을 터치해주세요!"); break;
            case 3: stageController.isFirst = 0; break;
        }

    }
}
