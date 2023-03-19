using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish_Speicification : MonoBehaviour
{
    public string jellName;
    public string jeliDescription;
    public GameObject keyboardInputPrefab;
    // Start is called before the first frame update
    private inputUISC inputComponenet;
    public int sellPrice;
    public int originalPrice;

    public string[] statusList;
    public string myStatus;
    public Color myColor1;
    public Color myColor2;

    float timer;
    float statusChangeTime = 30f;

    public void callInputString()
    {

        Instantiate(keyboardInputPrefab).GetComponent<inputUISC>().GetMethodfromCaller = changeName;


    }

    private void Start()
    {

        statusList = new string[] {
            "먹이 찾는 중", "새로운 친구 생각중 ", "열심히 수영 중", "물고기와 싸우는 상상 중", "먹이 찾는 중",
"잠자는 중", "해저 세계 탐험 중", "동료와 수영 중", "물고기와 춤추는 중", "즐거운 바닷속 구경 중",
"꼬리를 흔들며 수영 중", "사람들과 함께 놀기", "새로운 장소 탐험 중", "모든 것을 탐험 중",
"몸을 이리저리 흔들기", "부드러운 먹이 찾는 중", "즐겁게 놀기", "귀여운 모습으로 인사하기", "해파리 모임에서 수영하기",
"바닷속에서 날개짓하는 중", "플랑크톤과 함께 춤추는 중", "파도타기 중", "해저 동굴에서 쉬기", "해저 생물들과 함께 수영하기",
"보석 같은 해파리와 함께 수영하기", "해파리 수영 대회 참가하기", "무수한 별빛 아래 수영하기", "해파리 낚시하기", "여유로운 해파리 라이프 즐기기",
"수영으로 스트레스 해소하는 중", "자유롭게 헤엄치는 중", "바닷속 공연장에서 공연하기", "바다의 속삭임에 귀 기울이는 중",
"바닷속에서 여유를 느끼는 중"
            };

        changeStatus();
        statusChangeTime = Random.Range(15f, 100f);
        timer = 0f;
    }


    public void changeName(string inputString)
    {
        jellName = inputString;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > statusChangeTime)
        {
            changeStatus();
            statusChangeTime = Random.Range(15f, 100f);
            timer = 0f;
        }

        sellPrice = originalPrice + (int)(Mathf.Floor((gameObject.transform.Find("JLOBJ").transform.Find("JLFeature").GetComponent<JellyfishClickFeeding>().addedSize)/10))*10;
    }

    void changeStatus()
    {
        myStatus = statusList[Random.Range(0, statusList.Length)];

    }
}
