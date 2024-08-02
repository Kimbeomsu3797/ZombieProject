using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�÷��̾� ĳ���͸� �����ϱ� ���� ����� �Է��� ����
//������ �Է°��� �ٸ� ������Ʈ���� ����� �� �ֵ��� ����
public class PlayerInput : MonoBehaviour
{
    public string moveAxisName = "Vertical";
    public string rotateAxisName = "Horizontal";
    public string fireButtonName = "Fire1";
    public string reloadButtonName = "Reload";

    public float move { get; private set; } // ������ ������ �Է°� //Public�� propertyó�� ���� ���
    public float rotate { get; private set; }//������ ȸ�� �Է°�
    public bool fire { get; private set; }//������ �߻� �Է°�
    public bool reload { get; private set; }//������ ������ �Է°�
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���ӿ��� ���¿����� ������� �Է��� �������� �ʴ´�.
        /*if(GameManager.instance != null && GameManager.instance.isGameover)
        {
            move = 0;
            rotate = 0;
            fire = false;
            reload = false;
            return;
        }*/
        
        move = Input.GetAxis(moveAxisName);
        rotate = Input.GetAxis(rotateAxisName);
        fire = Input.GetButton(fireButtonName);
        reload = Input.GetButtonDown(reloadButtonName);
    }
}
