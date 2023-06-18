Jellyfishgame
Solo project
====

사전 목표
---
-> 개발시간 단축
- 1인 개발이기 때문에 최대한 효율적으로 계획할 필요

1. 그래픽 부문
- 리깅, 애니메이팅이 필요없는 해파리
- 대부분의 동작을 쉐이더 버텍스 매니퓰레이션으로 대체
- 포스트프로세싱(라이팅과 분위기)으로 어필 (조사 결과 인디게임은 분위기가 중요)


2. 게임 시스템
- 인터랙티브 한 월페이퍼 + 미니 게임의 방식
- 힐링 게임 표방 -> 광고 절대 없음(경험)
- 랜덤형 상태 표시로 해파리에게 인격, 감성
- 타이쿤 시스템을 차용

기대효과
-> 게임 제작 사이클 완성 경험
- 게임 시스템
- 라이팅, 사운드, ui, 터치, 배포 등 여러가지 문제 다뤄보기
- 세이브, 빌드 QA 등 게임의 최종 부분까지 완수해야 하는 파트 다뤄보기

대략적인 계획
|2월 말|3월 초|3월 말|4월 초|4월말|5월 초|5월 말|
|------|---|----|---|---|---|----|
|프로토타입완성|핵심 기능 구현|중간고사|세부 기능 추가|밸런스 조정|테스트 후 추가 기능 구현|테스트 후 출시|


세부 계획
---

프로토타입 완성 :
-UI프로토타입 제작(상점, 해파리 리스트 관리 UI(트래킹 기능))
-해파리 모델링, 쉐이더(vertex manimpulation, Bloom HDR)
-해파리 움직임 구현

핵심 기능 구현 :
-세이브 기능
-클릭 성장, 화폐 드랍, 성장 기능

세부 기능 추가 :
-성장 화폐 드랍 연결, 성장시 log함수 사용하여 속도 조절, 해파리의 색상 표시 UI 추가

밸런스 조정 :
-난이도 테스팅 및 세부 기능 조절 값 변화

테스트 후 추가 기능 구현
-지인들을 상대로 테스트 진행 -> 피드백

테스트 후 출시
-지인들을 상대로 테스트 진행 -> 큰 문제 없을 시 -> 출시



---

순서도
----
<img width="1085" alt="스크린샷 2023-06-18 오후 11 28 43" src="https://github.com/swimmin99/Jellyfishgame/assets/109887066/4bca4383-9bdd-4abc-8e84-10fd25650234">

<img width="668" alt="스크린샷 2023-06-18 오후 11 28 50" src="https://github.com/swimmin99/Jellyfishgame/assets/109887066/c76a519c-6cc4-4619-98bb-59f3bf99916d">



#개발로그
========

2/22 블렌더 사용
-------
![jellyfish](https://user-images.githubusercontent.com/109887066/227151352-b90d2f80-3077-431f-bd1a-acbd16e48be7.png)

문제상황 : 3D 모델링에 문외한이다.
해결방안 : 모델링을 전문적으로 배울 필요는 없으나 기본적인 동작이나 간단한 모델링은 배워두는게 좋다. 유튜브를 참고한다.
[참고영상]https://www.youtube.com/watch?v=Nm4fEI7JqC0
해결결과 : 영상을 보며 꼭 필요할 것으로 보이는 기능을 구글 검색을 통해 속성으로 배워 그럴듯한 모델을 만들어냈다. 어차피 일은 쉐이더가 다 할 것이다. 해결.

2/21 프로토타입
-------
![jellyfish2](https://user-images.githubusercontent.com/109887066/227154485-e11ffccc-f7ca-4fd9-a1e1-4f23710f0c37.gif)

세부사항 : 먹이를 주는 버튼과 수조, 해파리! 중요 3 요소를 아주 기초적인 수준으로 구현하였다.
핵심 요소 구현에서부터 시작한다.

#### 쉐이더

쉐이더는 해당 게임 구현에 있어서 매우 중요한 사항이다.

문제상황 : 나의 뻣뻣한 해파리 모델링이 유연하게 움직일 수 있도록 vertex shader을 적극적으로 조절 할 수 있는 방법이 필요하다.

해결방안 : 평소에도 많은 도움을 얻고 있는(이전에 Orthographic Water Shader을 만들 때 참고한적 있다) Cyanilux의 개발로그를 참조한다.
기억하자 바퀴를 다시 발명할 필요는 없다.

[참고링크](https://www.cyanilux.com/tutorials/jellyfish-shader-breakdown/)

해결결과 : 유연하게 움직이는 해파리를 구현했다. 그러나 새로운 문제 발생.
해파리가 어떻게 움직여야하지? 랜덤한 방향을 어떻게 지정하지? 해파리는 발광해야하는데?



2/22 전체적인 틀 구성
-------

<img src="https://user-images.githubusercontent.com/109887066/227152943-11b12944-fda0-487f-bbdc-7b317f4d5fff.png" width="300" height="400">

세부사항 : 전체적으로 모든 스마트폰의 홈화면과 크게 다르지 않도록 디자인하였다. 각 버튼들은 배타적으로 선택되어야 하므로 Toggle 기능을 사용하였다.

정사각형은 Stain 오브젝트로 더러워진 부분을 표현하는 얼룩이다. (추후 넣을지 고민중인 기능)


2/23 해파리으 부드러운 움직임
------

해결방안1 : 먼저 랜덤 포지션을 찍어서 해파리를 해당 방향을 향하여 이동하고 거리가 일정 수준 가까워지면 새로운 좌표를 랜덤으로 생성하여 이동하도록 해보자
해결방안1 결과 : 해파리는 움직인다. 그러나 새로운 랜덤 좌표를 받아올 때 뒤집어져 버린다!(새로운 문제1 발생)
문제1 - 해결방안1 : 부드러운 회전, 다시 말해 원형으로 움직여야 하는 것인가? 

![jellyfish3](https://user-images.githubusercontent.com/109887066/227160989-83dddb38-bc56-4d3b-bbe6-b40aae1d7acb.gif)

위와 같이 원점을 중심으로 삼차원 구에 해당하는 좌표만을 랜덤으로 받아와 회전하도록 하였다. 과연 결과는
문제1 - 해결방안1 결과 : 물론 이전보다는 부드럽게 움직이나 여전히 구에 해당하는 좌표라고 해도 반대쪽 좌표가 랜덤으로 나와버리면 뒤집혀 버린다. (새로운 문제 2 발생)
문제2 - 해결방안2 : 그렇다면 랜덤 좌표 범위를 조정하면 되는 게 아닌가? Range에 해당하는 변수를 조절해보았다.
문제2 - 해결방안2 결과 : 아쉽게도 범위를 조절해보아도 부자연스러운 움직임은 해소되지 않았다.
```
    void moveNaturalStateCoord()
    {
        xPos = targetObject.transform.localPosition.x + Random.Range(followerMinDistance, followerMaxDistance);
        yPos = targetObject.transform.localPosition.y + Random.Range(followerMinDistance, followerMaxDistance);
        zPos = targetObject.transform.localPosition.z + Random.Range(followerMinDistance, followerMaxDistance);
        desiredPos = new Vector3(xPos, yPos, zPos);
    }
```
```
    void naturalStateCoord()
    {
       location = new Vector3(followingObject.transform.position.x + Random.Range(-1*range, range),
       followingObject.transform.position.y + Random.Range(-1.5f, 1.5f),
       followingObject.transform.position.z + Random.Range(-1*range, range));
    }
```
-> 해당문제를 머리속 고민거리 대기열에 넣고 어떻게 되는지 지켜보자!

2/24 베지어곡선
------

![jellyfish4](https://user-images.githubusercontent.com/109887066/227162991-363b3cea-948b-4313-b3a9-e5b5140c8922.gif)

해결방안 :

최근에 인상깊게 보았던 수학 관련 유튜브의 시각화 영상에 베지어 곡선이 있었다. 해파리도 그렇게 움직이며 되는 것 아닌가?
움직임을 위해 3개의 좌표가 필요하다. 해파리의 현재 좌표, 해파리가 이동하고자 하는 목적지 좌표 그리고 기준으로 곡선으로 만들어 낼 또다른 제 3의 좌표. 
알아보기 쉽게 하기위해 형성된 각각 좌표의 위치에 빨간 구 모양의 Gizmo를 Draw했다. 

베지어 곡선 루트를 받아오는 함수는 아래와 같다.

```

Vector3 GetPointOnBezierCurve(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t){
        float u = 1f - t;
        float t2 = t * t;
        float u2 = u * u;
        float u3 = u2 * u;
        float t3 = t2 * t;

        Vector3 result =
            (u3) * p0 +
            (3f * u2 * t) * p1 +
            (3f * u * t2) * p2 +
            (t3) * p3;



        return result;}
    
 ```

해결결과 : 베지어 곡선을 왜 많이 사용하는지 이해할 정도로 아름답게 해결되었다. 수학은 역시 게임 디자인에 필수적이다.

2/25 UI 기틀
------
Ver 1.01 2023-02-25
-SHOP UI 프로토타입
-Jellyfish List UI 프로토타입
-UI
상점의 UI의 기본틀을 완성하였다. UGUI를 사용했으나 Layout과 Anchor의 개념이 헷갈려 오래걸렸다. 여전히 Anchor과 Allign with 의 기능은 어렵다.

Ver 1.02 2023-02-26
![UI1](https://user-images.githubusercontent.com/109887066/227167094-8d7c7f64-3b30-4824-a0d3-f6d238955170.gif)

원하는것 : 몰입이 가장 중요한 게임이다. 독 UI를 화면에 맞게 HIDE/SHOW 버튼이 필요하다.

해결방법1 : 코드르 짠다.

```
public void OnClickUI()
    {
        if (isDown == true && goingUp == false && goingDown == false)
        {
            goingUp = true;
            LeanTween.moveLocalY(gameObject, rectUItransform.localPosition.y - 200f, 0.5f).setEase(LeanTweenType.easeOutSine).setOnComplete(isUpFalse);
        }
        else if (isDown == false && goingUp == false && goingDown == false)
        {
            goingDown = true;
            LeanTween.moveLocalY(gameObject, rectUItransform.localPosition.y + 200f, 0.5f).setEase(LeanTweenType.easeOutSine).setOnComplete(isDownTrue);
        }
    }

    public void isUpFalse()
    {
        isDown = false;
        goingUp = false;
    }

    public void isDownTrue()
    {
        isDown = true;
        goingDown = false;
    }
```

화면 크기와 UI rectUItransform의 크기를 받아와 이동시킨다. 부드러운 이동이 아니다 보니 부자연스럽다 (문제발생)

문제 해결방법 : 바퀴를 다시 발명할 필요는 없다고 했다. 훌륭한 개발자들께서 유니티 애셋스토어에 UI 특화 애니메이션 애셋을 만들어두셨다.
[참고링크](https://assetstore.unity.com/packages/tools/animation/leantween-3595)

LeanTween 이외에도 Dotween 등 여러 Tweening 툴이 있으나 그나마 익숙한 LeanTween을 사용한다.


Ver 1.02 2023-02-27
-해파리 트래킹 상태 표시 UI, TOGGLE, 삭제 구현 완료
Toggle로 해파리의 사태를 표시하고 트래킹 시 선택됨 표시의 UI가 해파리 상단에 표시되도록 했다.
다음은 리스트를 불러오기 위한 메서드이다.
```

 void GenerateList()
    {
        

        blankWarningUI.SetActive(false);

        List<GameObject> tag_targets = new List<GameObject>();

        tag_targets = refresher.refresher();

        if (tag_targets == null || tag_targets.Count == 0)
        {
            blankWarningUI.SetActive(true);
        }
        else
        {

            drawButtons(tag_targets);
            foreach (GameObject go in tag_targets)
            {
                print(go.name);
            }
        }
    }
```


1) 단기 목표 : UI Screen Position to world position -> 해결
2) UI : BLUR 효과가 있는 UI를 쉐이를 사용하여 구현하여보자.  -> Blur은 Computing Power 너무 많이사용 -> 비효율적 컨셉 폐기 단순 미니멀 UI로 선회




3/1~3/10경 세이브 모드의 구현
------

UI polishing이 끝나고 세이브를 구현한다.
JSON FILE을 저장할 쉽고 효율적인 방법을 찾자.

Stack Overflow의 도움으로 찾은 아래 코드를 참조한다. (보일러 플레이트 코드)
[출처](https://stackoverflow.com/questions/36239705/serialize-and-deserialize-json-and-json-array-in-unity)

3/20~4/10경 중간고사 대비와 함께 공모전 대비와 함께 개발
------
3/19 배경 변화 기능을 제대로 추가한다.
```

    Color GetHexaToColor(string hexacode) {
        Color myColor;
        ColorUtility.TryParseHtmlString(hexacode, out myColor);

        return myColor;
    }
```
손쉽게 Hexa to Color(Vector 4)로 바꿔주는 코드이다. (보일러 플레이트 코드)
```

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
```


#3/20~4/10
중간고사와 데드라인이 겹쳐버렸다. 더군다나 공모전에도 출품해야하는데...
크런치모드
대부분의 UI와 사잊 조절, 피딩 기능 또한 쓰레싱 문제까지 크런치 모드 중에 업데이트 되었다.
먹이 줄 시에 커지는 사이즈 등의 수를 맞추는 과정을 거친다.


3/31 새로운 세가지 해파리 모델을 적용
1단계 : 아기 해파리
2단계 : 준성체 해파리
3단계 : 성체 해파리
각각을 Blender을 사용해 모델링 했으며 먹이 클릭 양에 맞추 변화하도록 Case문을 사용해 코드 작성
```
 switch (level)
                {
                    case 1:
                        if (sizeIncrease > level1Size)
                        {
                            GetComponent<MeshFilter>().mesh = meshMiddle; level++;
                            playParticles(particleUpgrade1);
                            if(jellyfishListUI.activeSelf == true)
                                jellyfishListUI.transform.Find("Scroll View").Find("Viewport").Find("Content").GetComponent<JellyfishListUI>

```

이후 방생 기능을 추가한다.
```

  buttonGroup.transform.Find("FreeButton").GetComponent<Button>().onClick.AddListener(() => {
                writeToFreeList();
                gameObject.transform.parent.transform.parent.gameObject.SetActive(false);
                popup.SetActive(false);
                Destroy(gameObject.transform.parent.transform.parent.gameObject);
                Destroy(popup);
                particleSetFree.SetActive(true);
                if(jellyfishListUI.activeSelf== true)
                jellyfishListUI.transform.Find("Scroll View").Find("Viewport").Find("Content").GetComponent<JellyfishListUI>().Refresh();

            });
```

펫 기능의 구현

상점에서 언락 버튼
```

    public void ActivateProduct()
    {
        print((int)Mathf.Pow(4, buttonNum));
        if ((int)Mathf.Pow(4,buttonNum) <= stageController.freelist.Count)
        {
            if (targetObject.activeSelf)
            {
                targetObject.SetActive(false);
                stageController.petunlock[buttonNum] = 0;
            }
            else
            {
                targetObject.SetActive(true);
                stageController.petunlock[buttonNum] = 1;
            }
        }
        else
        {
            int num = (int)stageController.freelist.Count - (int)Mathf.Pow(4, buttonNum);
            GameObject temp;
            temp = Instantiate(AlertPrefab);
            string localizedString = LocalizationSettings.StringDatabase.GetLocalizedString("ScriptLocalization", "moreToFree");
            temp.GetComponent<AlertCS>().CautionString = (int)Mathf.Abs(num) + localizedString;
            temp.SetActive(true);
        }
    }
```


4/16~ 휴식
------
중간고사 관계로 개발 중단

4/26~ 개발 재개
------
개발 재시작


캠페인 모드 개발을 시작하다.


~5/10 캠페인 모드 개발의 착수
------
![스크린샷3](https://github.com/swimmin99/Jellyfishgame/assets/109887066/30893bb4-c335-46a0-9373-9cc51320defa)

전체적인 UI 게임의 전체적인 구성은 제작 완료되었다.
기본 모드의 제작 로그는 여기서 잠깐 중단된다.
캠페인 모드 제작에 앞서 TemperatureControl 기능을 넣어 스크립트를 작성한다.
```
 if (CrisisIsOn == false)
                {
                    upperSideBar.SetActive(false);
                
                    Triangle.SetActive(false);
                    GetComponent<Button>().interactable = false;
                    DisplayCaution.SetActive(false);
                    UI.color = Color.white;
                    CrisisTimer += Time.deltaTime;
                    if (isAdjusting == false)
                    {
                        neutralTimer += Time.deltaTime;
                        displayTemper = Mathf.MoveTowards(displayTemper, neutralTemper, Time.smoothDeltaTime / 5f);

                        if (neutralTimer > neutralTime)
                        {
                            neutralTimer = 0f;
                            neutralTime = Random.Range(3, 7);
                            neutralTemper = Random.Range(minTemperature, maxTemperature);
                        }
                    }
                    if (CrisisTimer > CrisisTime)
                    {
                        isAdjusting = true;
                        displayTemper = Mathf.MoveTowards(displayTemper, CrisisTemper, 1f * Time.smoothDeltaTime);
                        if (displayTemper == CrisisTemper)
                        {
                            isAdjusting = false;
                            CrisisIsOn = true;
                            DuringCrisisTimer = 0f;
                        }
                    }

                }
              
```
~5/12 캠페인 모드 개발의 착수
------
![스크린샷4](https://github.com/swimmin99/Jellyfishgame/assets/109887066/17d603ee-c8e9-48c8-b9dc-40730f36f5a5)

캠페인 모드 개발 중에 추가했던 기능인 전체 화면 파티클 이펙트를 기본 모드에도 추가했다.

충분한 심사 숙고 끝에 캠페인 모드로 위기 상황을 추가하는 것은 애초에 로드맵에 없었으며 계획이 크게 뒤틀린다.
파티클 이펙트를 본 기본 게임모드에 적용시키고 TemperatureManager 기능은 폐기한다.


~5/12 최적화와 빌드 그리고 플레이콘솔
------
캠페인 모드 개발이 길어질 것으로 예상되어 기본 모드로 사전 출시를 감행한다.
아주 간단한 최적화와 테스팅 과정을 거치고 플레이 콘솔에 등록한다.

플레이콘솔은 개발자 등록비용이 있다.
개인정보처리방침을 게시해야한다.

나만의 웹이 필요하다
괜찮다. 만들면 된다.

이제 모든 사항을 기입하였으니 출시할 차례이다.

~5/15 마지막 욕심
------
![스크린샷5](https://github.com/swimmin99/Jellyfishgame/assets/109887066/dca4a8cd-b514-4c8e-a561-ce7432e69938)
출시 직전에 방생한 해파리를 볼 수 있으면 어떨까라는 생각이 들었다. 
다시 수정을 가한다. 괜찮다 이번에는 GPT가 있다. GPT가 틀을 짜고 내가 리바이징 하며 좋은 코드를 만들어나간다.
```

 public void FindPosition(Vector2 coordinate)
    {
        // Convert spherical coordinates to a point on the unit sphere
        float latitude = coordinate.x * Mathf.Deg2Rad;
        float longitude = coordinate.y * Mathf.Deg2Rad;
        Vector3 pointOnUnitSphere = new Vector3(
            Mathf.Cos(latitude) * Mathf.Sin(longitude),
            Mathf.Sin(latitude),
            Mathf.Cos(latitude) * Mathf.Cos(longitude)
        );

        // Calculate the rotation needed to align this point with Vector3.up
        Quaternion targetRotation = Quaternion.FromToRotation(pointOnUnitSphere, Vector3.up);

        // Start the rotation to the target position
        StartCoroutine(RotateToTarget(targetRotation, rotationDuration));
    }
```

##5/17 Jellyfish has turned Gold
------

2023년 6월 3일 오후 12:18
---
![feed](https://github.com/swimmin99/Jellyfishgame/assets/109887066/10ef7e03-aa83-4ab0-b861-423cb43ea64d)

편의성
-폰트 크기 확대
-Money(젤리) 터치 범위 확대
-Money(젤리) 획득 시 사운드 추가
-UI 구분선 추가
기능
-평상시 행성 3D 모델 횡축으로 회전하는 기능 추가

출시일: 6월 4일 오전 9:25
---
![news](https://github.com/swimmin99/Jellyfishgame/assets/109887066/45f0cfc2-4857-4784-9264-632a12a7c21f)
information창 폰트 크기 확대
바다 속 세상 뉴스 표시 기능 추가
물 환수 기능 추가!
너무 오랜 시간동안 자리를 비우면 10젤리를 사용하여
물을 환수해야 합니다! 잊지말고 한번씩 들러 주세요~

버그 픽스
-최초 실행시 뉴스 고정 출력 버그 수정

출시일: 6월 5일 오후 4:56
---
![clean](https://github.com/swimmin99/Jellyfishgame/assets/109887066/d020d88c-086c-4c73-a546-a089a35fca23)
청소 기능이 추가되었습니다~ 원하는 때에 해파리 목록 창으로 들어가 환수할 수 있습니다.(물청소)
너무 오랜 시간 접속 하지 않으면 수족관이 더러워져 청소 시 비용이 발생하니 자주 방문해주세요!~
배경음악 반복 버그 수정
젤리 무한 드랍 버그 수정
뉴스 티커 뉴스 배너 형 사이드 스크롤링으로 변경
환수(청소)기능 추가

출시일: 6월 5일 오후 6:17
---

먹이 업그레이드 버그 수정!
피드백 감사합니다~

출시일: 6월 6일 오전 10:42
---
![color](https://github.com/swimmin99/Jellyfishgame/assets/109887066/951afe2b-42b4-478f-95d3-129b1a6e6be1)

기능 추가
해파리 구입 가능 색상 목록이 다양해 졌습니다.
가격 밸런스조정
방생 판매 선택 팝업 이전에 경고 문구 추가
방생 리스트 목록 출력 오류 문제 해결

출시일: 6월 6일 오후 12:12
---

여러분의 성원에 힘입어
-기능 추가
해파리 구입 가능 색상 목록이 다양해 졌습니다.
가격 밸런스조정
방생 판매 선택 팝업 이전에 경고 문구 추가

-버그 픽스
방생 리스트 목록 출력 오류 문제 해결
펫 언락 시 저장 안되는 버그 픽스
펫 시스템 전반적인 버그 픽스
배경 변경 텍스트 오류 픽스

출시일: 6월 6일 오후 7:12
---

먹이 업그레이드 밸런싱 & 버그픽스 했습니다.

출시일: 6월 6일 오후 11:19
---

free버튼 버그 픽스
해파리 판매 밸런스 조절
청소버튼 위치조절

출시일: 6월 6일 오후 11:59
---

이제 비싼 해파리일수록 더 비싼 젤리를 생성하고,
더욱 비싼 가격에 팔립니다.

전체적으로 상점 카탈로그의 가격이 상승하였습니다.

먹이 업그레이드의 가격이 상승하였습니다.

출시일: 6월 8일 오후 3:48
---
![eng](https://github.com/swimmin99/Jellyfishgame/assets/109887066/6efb241d-b7c4-4ddd-930b-7eb9fe54bf70)
먹이 업그레이드 코드 내 상수값 오기재 오류 수정했습니다!! 버그 제보 감사합니다~
영어를 지원합니다!
Now Supports English!
버그픽스
해파리 판매 금액 계산 식을 개선하였습니다.
BugFix
Recalibrated jellyfish price getting equation.

please send any bug to the email below or any other contact channels.
devhanghae@gmail.com
이제 다국어를 지원합니다!
영어를 사용하실 분은 설정에서 언어를 변경하실 수 있습니다.
(사용 도중 언어를 바꾸는 것을 권장드리진 않습니다.)

해파리 판매 가격 수식을 개선하였습니다.
젤리 금액 표시 UI 버그를 수정하였습니다.
Now supporting multi-language!
Fixed the equation of selling jellyfish.
Fixed ui displaying jelly(money)
Fixed minor bugs for UI.
Please report bugs all translation errors!
devhanghae@gmail.com


출시일: 6월 10일 오전 10:51
---

스플래쉬이미지 교체
튜토리얼 이미지가 변경되었습니다.

UI fixed
Splash image redone
Jellyfish view button UI fixed.
tutorial image has been changed for localization!

출시일 : 6월 17일 오후
---
![ui1](https://github.com/swimmin99/Jellyfishgame/assets/109887066/f99d2621-f67a-4d36-b679-0967787f0d06)
![ui2](https://github.com/swimmin99/Jellyfishgame/assets/109887066/7a70f866-de89-4842-b915-68fb53004ce1)


추가적인 버그를 업데이트 중에 있습니다. 
다음 업데이트 예고 : 
젤리 무한 증식 오류 개선
탐험 기능 추가

Update:
UI Overhaul!
===============
For the next update:
Fixing infinite jelly bug is in progress
Adding Key feature "Adventure" in progress
