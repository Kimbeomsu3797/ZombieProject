using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class IDamageAble
{
    void TestFunction();    //메서드(함수)
    int myInt { get; set; } // 프로퍼티
    event EventHandler OnMyEvent;   //이벤트
}
*/

//아이템 타입들이 반드시 구현해야 하는 인터페이스
public interface IItem
{
    // 입력으로 받는 target은 아이템 효과가 적용될 대상
    void Use(GameObject target);
}

public interface IDamageable
{
    void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal);
}

public class Interface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
