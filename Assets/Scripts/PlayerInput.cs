using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//플레이어 캐릭터를 조작하기 위한 사용자 입력을 감지
//감지된 입력값을 다른 컴포넌트들이 사용할 수 있도록 제공
public class PlayerInput : MonoBehaviour
{
    public string moveAxisName = "Vertical";
    public string rotateAxisName = "Horizontal";
    public string fireButtonName = "Fire1";
    public string reloadButtonName = "Reload";

    public float move { get; private set; } // 감지된 움직임 입력값 //Public을 property처럼 쓰는 방법
    public float rotate { get; private set; }//갑지된 회전 입력값
    public bool fire { get; private set; }//감지된 발사 입력값
    public bool reload { get; private set; }//감지된 재장전 입력값
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //게임오버 상태에서는 사용자의 입력을 감지하지 않는다.
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
