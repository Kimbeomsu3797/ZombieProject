using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//���� ����� ��ũ��Ʈ
//�޼��� �ε���, ������Ƽ,�̺�Ʈ ���� �͸� ���� �� ����
public interface IDamageAble
{
    void TestFuntion();
    int myInt { get; set; }
    event EventHandler OnMyEvent;
}
//�ܼ��� ������ ����� ����. ������Ƽ�� �����
//������� �������� ���� ����
//�����Ѱ� �ٲٱ� ��������
//�ѹ� ������ �� ����� �ؾ���
