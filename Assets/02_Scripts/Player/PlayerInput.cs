using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string moveAxisName = "Vertical";
    public string rotateAxixName = "Horizontal";
    public string fireButtonName = "Fire1";
    public string reloadButtonName = "Reload";

    public float move { get; private set; }     // 감지된 움직임 입력값
    public float rotate { get; private set; }   // 감지된 회전 입력값
    public bool fire { get; private set; }      // 감지된 발사 입력값
    public bool reload { get; private set; }    // 감지된 재장전 입력값

    void Start()
    {
        
    }

    // 매 프레임 사용자 입력 감지
    void Update()
    {
        /*
        // 게임 오버 상태에서는 사용자 입력을 감지하지 않는다
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
