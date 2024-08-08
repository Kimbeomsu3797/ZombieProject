using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ Ÿ�Ե��� �ݵ�� �����ؾ��ϴ� �������̽�
public interface IItem
{
    // �Է����� �޴� target�� ������ ȿ���� ����� ���
    void Use(GameObject target);
}

public interface IDamageable
{
    void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {

    }
}
