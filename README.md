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

개발 진척 사항
Ver 1.00 2023-02-22
- 해파리 쉐이더 완성
- 해파리 이동 매커니즘 스크립팅 완성(선형이동 -> 베이지어 곡선을 이용한 부드러운 이동)
Ver 1.01 2023-02-24
-SHOP UI 프로토타입
-Jellyfish List UI 프로토타입
-UI
Ver 1.02 2023-02-27
-해파리 트래킹 상태 표시 UI, TOGGLE, 삭제 구현 완료


1) 단기 목표 : UI Screen Position to world position -> 해결
2) UI : BLUR 효과가 있는 UI를 쉐이를 사용하여 구현하여보자.   
---
개발로그
=======
2/22 블렌더를 두려워하지 말자!
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


2/22 틀을 짜는 것이 먼저!
-------

<img src="https://user-images.githubusercontent.com/109887066/227152943-11b12944-fda0-487f-bbdc-7b317f4d5fff.png" width="300" height="400">

세부사항 : 전체적으로 모든 스마트폰의 홈화면과 크게 다르지 않도록 디자인하였다. 각 버튼들은 배타적으로 선택되어야 하므로 Toggle 기능을 사용하였다.

정사각형은 Stain 오브젝트로 더러워진 부분을 표현하는 얼룩이다. (추후 넣을지 고민중인 기능)


2/23 해파리야 제발 부드럽게 움직여라!
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

2/24 그 함수... 뭐였지!
------

![jellyfish4](https://user-images.githubusercontent.com/109887066/227162991-363b3cea-948b-4313-b3a9-e5b5140c8922.gif)

해결방안 :

머리한켠에서 계속 생각하다보니 무언가 떠오르는게 분명 있었다. 퀘퀘한 기억 언저리에 숨겨진 그것은 오래전에 유튜브에서 보았던 베지어 곡선에 대하 영상이었다. 물론 그땐 베지어 곡선이 적용되는 여러곳 혹은 부드럽게 이어지는 그래프를 넋놓고 시간 때우기로 보기만 했었다. 이제 그 시간이 빛을 발할 때가 왔다. 해파리도 그렇게 움직이며 되는 것 아닌가?

움직임을 위해 3개의 좌표가 필요했다. 해파리의 현재 좌표, 해파리가 이동하고자 하는 목적지 좌표 그리고 기준으로 곡선으로 만들어 낼 또다른 제 3의 좌표. 알아보기 쉽게 하기위해 형성된 각각 좌표의 위치에 빨간 구 모양의 Gizmo를 Draw했다. 

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

[UI1](https://user-images.githubusercontent.com/109887066/227167094-8d7c7f64-3b30-4824-a0d3-f6d238955170.gif)

UI를 본격적으로 디자인하기 전부터 불안감과 귀찮음이 엄습했다.
하지만 UI 없는 게임이 어디있는가? 어차피 해야할 건 제대로 해야한다.

원하는것 : 몰입이 가장 중요한 게임이다. 힐링으 위해 해파리가 중요한데 UI가 가리며 쓰나! 독 UI를 화면에 맞게 HIDE/SHOW 버튼이 필요하다.

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

화면 크기와 UI rectUItransform의 크기를 받아와 이동시킨다. 그렇지만 보기 싫게 휙휙 바뀔 순 없다. 적어도 나의 게임에선.(문제 발생)

문제 해결방법 : 바퀴를 다시 발명할 필요는 없다고 했다. 훌륭한 개발자들께서 유니티 애셋스토어에 UI 특화 애니메이션 애셋을 만들어두셨다.
[참고링크](https://assetstore.unity.com/packages/tools/animation/leantween-3595)
LeanTween 이외에도 Dotween 등 여러 Tweening 툴이 있으나 그나마 익숙한 LeanTween을 사용한다.


-해파리 트래킹 상태 표시 UI, TOGGLE, 삭제 구현 완료ㅜㄴ
-해파리 트래킹 상태 표시 UI, TOGGLE, 삭제 구현 완료제
-해파리 트래킹 상태 표시 UI, TOGGLE, 삭제 구현 완료

3/19 세이브와의 전쟁!
------


우

워

