using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class IDamageAble
{
    void TestFunction();    //�޼���(�Լ�)
    int myInt { get; set; } // ������Ƽ
    event EventHandler OnMyEvent;   //�̺�Ʈ
}
*/

//������ Ÿ�Ե��� �ݵ�� �����ؾ� �ϴ� �������̽�
public interface IItem
{
    // �Է����� �޴� target�� ������ ȿ���� ����� ���
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
