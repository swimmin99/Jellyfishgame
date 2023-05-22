# Jellyfishgame
Solo project

목표

1. 개발시간 단축
- 리깅, 애니메이팅이 필요없는 해파리
- 대부분의 동작을 쉐이더 버텍스 매니퓰레이션으로 대체
- 라이팅과 분위기로 어필

2. 간단한 게임 매커닉
- 방치형 게임 매커닉
- 힐링 게임 표방

3. 게임 제작 사이클 완성
- 게임 시스템
- 라이팅, 사운드, ui, 터치, 배포 등 여러가지 문제 다뤄보기


|2월 말|3월 초|3월 말|4월 초|4월말|5월 초|5월 말|
|------|---|----|---|---|---|----|
|프로토타입완성|핵심 기능 구현|중간고사|세부 기능 추가|밸런스 조정|테스트 후 추가 기능 구현|테스트 후 출시|

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




2/22 블렌더 사용
-------
![jellyfish](https://user-images.githubusercontent.com/109887066/227151352-b90d2f80-3077-431f-bd1a-acbd16e48be7.png)

문제상황 : 3D 모델링에 문외한이다.
해결방안 : 모델링을 전문적으로 배울 필요는 없으나 기본적인 동작이나 간단한 모델링은 배워두는게 좋다. 유튜브로 가자.
[참고영상]https://www.youtube.com/watch?v=Nm4fEI7JqC0
해결결과 : 영상을 보며 꼭 필요할 것으로 보이는 기능을 구글 검색을 통해 속성으로 배워 그럴듯한 모델을 만들어냈다. 어차피 일은 쉐이더가 다 할 것이다. 해결.

2/21 프로토타입의 모습!
-------
![jellyfish2](https://user-images.githubusercontent.com/109887066/227154485-e11ffccc-f7ca-4fd9-a1e1-4f23710f0c37.gif)

세부사항 : 먹이를 주는 버튼과 수조, 해파리! 중요 3 요소를 아주 기초적인 수준으로 구현하였다. 이것이 기틀이 될 것이다.
#### 쉐이더

쉐이더는 해당 게임 구현에 있어서 매우 중요한 사항이다.

문제상황 : 나의 뻣뻣한 해파리 모델링이 유연하게 움직일 수 있도록 vertex shader을 적극적으로 조절 할 수 있는 방법이 필요하다.

해결방안 : 평소에도 많은 도움을 얻고 있는(이전에 Orthographic Water Shader을 만들 때 참고한적 있다) Cyanilux의 개발로그를 참조한다.

기억하자 바퀴를 다시 발명할 필요는 없다!

[참고링크](https://www.cyanilux.com/tutorials/jellyfish-shader-breakdown/)

해결결과 : 유연하게 움직이는 해파리를 구현했다. 그러나 새로운 문제가 발생한다. 해파리가 어떻게 움직여야하지? 랜덤한 방향을 어떻게 지정하지? 해파리는 발광해야하는데?

하나하나 해결해가도록하자


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

2/25 UI와의 전쟁!
------
Ver 1.01 2023-02-25
-SHOP UI 프로토타입
-Jellyfish List UI 프로토타입
-UI
상점의 UI의 기본틀을 완성하였다. UGUI를 사용했으나 Layout과 Anchor의 개념이 헷갈려 오래걸렸다. 여전히 Anchor과 Allign with 의 기능은 어렵다.

Ver 1.02 2023-02-26
[UI1](https://user-images.githubusercontent.com/109887066/227167094-8d7c7f64-3b30-4824-a0d3-f6d238955170.gif)

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

1) 단기 목표 : UI Screen Position to world position -> 해결
2) UI : BLUR 효과가 있는 UI를 쉐이를 사용하여 구현하여보자.  -> Blur은 Computing Power 너무 많이사용 -> 비효율적 컨셉 폐기 단순 미니멀 UI로 선회


3/1~3/10경 세이브 모드의 구현
------

UI polishing이 끝나고 세이브를 구현한다.
JSON FILE을 저장할 쉽고 효율적인 방법을 찾자.

Stack Overflow의 도움으로 찾은 아래 코드를 참조한다.
[출처](https://stackoverflow.com/questions/36239705/serialize-and-deserialize-json-and-json-array-in-unity)
```
Your Json contains multiple data objects. For example playerId appeared more than once. Unity's JsonUtility does not support array as it is still new but you can use a helper class from this person to get array working with JsonUtility.

Create a class called JsonHelper. Copy the JsonHelper directly from below.

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
Serializing Json Array:

Player[] playerInstance = new Player[2];

playerInstance[0] = new Player();
playerInstance[0].playerId = "8484239823";
playerInstance[0].playerLoc = "Powai";
playerInstance[0].playerNick = "Random Nick";

playerInstance[1] = new Player();
playerInstance[1].playerId = "512343283";
playerInstance[1].playerLoc = "User2";
playerInstance[1].playerNick = "Rand Nick 2";

//Convert to JSON
string playerToJson = JsonHelper.ToJson(playerInstance, true);
Debug.Log(playerToJson);
Output:

{
    "Items": [
        {
            "playerId": "8484239823",
            "playerLoc": "Powai",
            "playerNick": "Random Nick"
        },
        {
            "playerId": "512343283",
            "playerLoc": "User2",
            "playerNick": "Rand Nick 2"
        }
    ]
}
Deserializing Json Array:

string jsonString = "{\r\n    \"Items\": [\r\n        {\r\n            \"playerId\": \"8484239823\",\r\n            \"playerLoc\": \"Powai\",\r\n            \"playerNick\": \"Random Nick\"\r\n        },\r\n        {\r\n            \"playerId\": \"512343283\",\r\n            \"playerLoc\": \"User2\",\r\n            \"playerNick\": \"Rand Nick 2\"\r\n        }\r\n    ]\r\n}";

Player[] player = JsonHelper.FromJson<Player>(jsonString);
Debug.Log(player[0].playerLoc);
Debug.Log(player[1].playerLoc);
Output:

Powai

User2
If this is a Json array from the server and you did not create it by hand:

You may have to Add {"Items": in front of the received string then add } at the end of it.

I made a simple function for this:

string fixJson(string value)
{
    value = "{\"Items\":" + value + "}";
    return value;
}
then you can use it:

string jsonString = fixJson(yourJsonFromServer);
Player[] player = JsonHelper.FromJson<Player>(jsonString);
3.Deserialize json string without class && De-serializing Json with numeric properties

This is a Json that starts with a number or numeric properties.

For example:

{ 
"USD" : {"15m" : 1740.01, "last" : 1740.01, "buy" : 1740.01, "sell" : 1744.74, "symbol" : "$"}, 

"ISK" : {"15m" : 179479.11, "last" : 179479.11, "buy" : 179479.11, "sell" : 179967, "symbol" : "kr"},

"NZD" : {"15m" : 2522.84, "last" : 2522.84, "buy" : 2522.84, "sell" : 2529.69, "symbol" : "$"}
}
Unity's JsonUtility does not support this because the "15m" property starts with a number. A class variable cannot start with an integer.

Download SimpleJSON.cs from Unity's wiki.

To get the "15m" property of USD:

var N = JSON.Parse(yourJsonString);
string price = N["USD"]["15m"].Value;
Debug.Log(price);
To get the "15m" property of ISK:

var N = JSON.Parse(yourJsonString);
string price = N["ISK"]["15m"].Value;
Debug.Log(price);
To get the "15m" property of NZD:

var N = JSON.Parse(yourJsonString);
string price = N["NZD"]["15m"].Value;
Debug.Log(price);
```

3/20~4/10경 중간고사 대비와 함께 공모전 대비와 함께 개발
------
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


4/16~ 휴식
------
중간고사 관계로 개발 중단

4/26~ 개발 재개
------
개발 재시작
캠페인 모드 개발을 시작하다.

-해파리 트래킹 상태 표시 UI, TOGGLE, 삭제 구현 완료ㅜㄴ
-해파리 트래킹 상태 표시 UI, TOGGLE, 삭제 구현 완료제
-해파리 트래킹 상태 표시 UI, TOGGLE, 삭제 구현 완료

~5/10 캠페인 모드 개발의 착수
------
![스크린샷3](https://github.com/swimmin99/Jellyfishgame/assets/109887066/30893bb4-c335-46a0-9373-9cc51320defa)
전체적인 UIㅇ 게임의 전체적인 구성은 제작 완료되었다.
기본 모드의 제작 로그는 여기서 잠깐 중단된다. 캠페인 모드느 번외에 개발로그를 작성할 계획이다.

~5/12 캠페인 모드 개발의 착수
------
![스크린샷4](https://github.com/swimmin99/Jellyfishgame/assets/109887066/63f3fb4d-64d9-4ab8-8454-914680243654)
캠페인 모드 개발 중에 추가했던 기능인 전체 화면 파티클 이펙트를 기본 모드에도 추가했다.

~5/12 최적화와 빌드 그리고 플레이콘솔
------
캠페인 모드 개발이 길어질 것으로 예상되어 기본 모드로 사전 출시를 감행한다.
아주 간단한 최적화와 테스팅 과정을 거치고 플레이 콘솔에 등록한다.

플레이콘솔은 개발자 등록비용이 있다.
개인정보처리방침을 게시해야한다.

나만의 웹이 필요하다ㅠㅠㅠ
괜찮다. 만들면 된다.
hanghae.xyz 확인해보라!

이제 모든 사항을 기입하였으니 출시할 차례이다.

~5/15 마지막 욕심
------
출시 직전에 방생한 해파리를 볼 수 있으면 어떨까라는 생각이 들었다. 
![스크린샷5](https://github.com/swimmin99/Jellyfishgame/assets/109887066/08d2d7c1-62a7-4300-8681-1ae47e7c6310)
다시 수정을 가한다. 괜찮다 이번에는 GPT가 있다. GPT가 틀을 짜고 내가 리바이징 하며 좋은 코드를 만들어나간다.
```

using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.ProBuilder.Shapes;

public class SphereController : MonoBehaviour
{
    public float rotationSpeed = 0.1f; // 회전하는 속도
    public float rotationDuration = 1f; // 회전하는 시간
    public AnimationCurve rotationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1); // Curve for the rotation to the target position
    public ParticleSystem particleSystem; // 파티클 시스템 연결

    private bool isRotatingToTarget = false; // 회전 상태 체크 불리언

    private void OnEnable()
    {
        isRotatingToTarget = false;
        particleSystem.Stop();
        // Start the constant rotation around the y-axis
        StartRotation();
    }

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

    private void StartRotation()
    {
        isRotatingToTarget = false;
    }

    private void StopRotation()
    {
        isRotatingToTarget = true;
        particleSystem.Play();
    }

    private System.Collections.IEnumerator RotateToTarget(Quaternion targetRotation, float duration)
    {
        StopRotation();

        Quaternion startRotation = transform.rotation;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            float easedT = rotationCurve.Evaluate(t);
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, easedT);
            yield return null;
        }

        transform.rotation = targetRotation;

        particleSystem.Stop();
    }

    public Vector2 GenerateCoordinates(string name, string dateTimeNow, string statusList)
    {
        // Concatenate the input strings and compute their hash
        string combinedInput = name + dateTimeNow + statusList;
        byte[] inputBytes = Encoding.UTF8.GetBytes(combinedInput);
        byte[] hashBytes;

        using (SHA256 sha256 = SHA256.Create())
        {
            hashBytes = sha256.ComputeHash(inputBytes);
        }

        // Convert the first two bytes of the hash to a latitude and longitude
        float latitude = (hashBytes[0] / 256f) * 180f - 90f;  // Range: [-90, 90]
        float longitude = (hashBytes[1] / 256f) * 360f - 180f;  // Range: [-180, 180]

        return new Vector2(latitude, longitude);
    }
}
```

5/17 Jellyfish has turned Gold
------
구글 플레이 콘솔에 게시 완료하였다. 검토 중이며 출시 완료 시 즉각 게시 될 것이다.

5/21
개인정보처리방침에 문제가 있어 rejection mail을 받았다.
해당부분을 수정하였다.

5/22
마켓에 올라왔다. 드디어.

나 자신 수고했다.



