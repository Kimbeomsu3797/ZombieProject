using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string moveAxisName = "Vertical";
    public string rotateAxixName = "Horizontal";
    public string fireButtonName = "Fire1";
    public string reloadButtonName = "Reload";

    public float move { get; private set; }     // ������ ������ �Է°�
    public float rotate { get; private set; }   // ������ ȸ�� �Է°�
    public bool fire { get; private set; }      // ������ �߻� �Է°�
    public bool reload { get; private set; }    // ������ ������ �Է°�

    void Start()
    {
        
    }

    // �� ������ ����� �Է� ����
    void Update()
    {
        /*
        // ���� ���� ���¿����� ����� �Է��� �������� �ʴ´�
        if ( GameManager.instance != null && GameManager.instance.isGameover)
        {
            move = 0;
            rotate = 0;
            fire = false;
            reload = false;
            return;
        }*/

        move = Input.GetAxis(moveAxisName);
        rotate = Input.GetAxis(rotateAxixName);
        fire = Input.GetButton(fireButtonName);
        reload = Input.GetButtonDown(reloadButtonName);
    }
}
