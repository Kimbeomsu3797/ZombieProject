using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//문법 설명용 스크립트
//메서드 인덱스, 프로퍼티,이벤트 같은 것만 받을 수 있음
public interface IDamageAble
{
    void TestFuntion();
    int myInt { get; set; }
    event EventHandler OnMyEvent;
}
//단순한 변수는 멤버로 못씀. 프로퍼티로 써야함
//멤버들을 구현없이 선언만 가능
//선언한거 바꾸기 쉽지않음
//한번 선언할 때 제대로 해야함
