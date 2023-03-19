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
            case 1: display("해달 OT용 빌드" + '\n'+ "Ver3.0"); break;
            case 2: display("환영합니다!" + '\n' + "인영님"); break;
            case 3: display("상점에서 해파리를" + '\n' +"구입해 주세요!"); break;
            case 4: stageController.isFirst = 0; Destroy(gameObject); break;
        }

    }
}
