using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Gun gun;             // 사용할 총
    public Transform gunPivot;  // 총 배치의 기준점
    public Transform leftHandMount;     // 총의 왼쪽 손잡이, 왼손이 위치할 지점
    public Transform rightHandMount;    // 총의 오른쪽 손잡이, 오른손이 위치할 지점

    PlayerInput playerInput;    // 플레이어의 입력
    Animator playerAnim;        // 애니메이터 컴포넌트

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        // 슈터가 활성화 될 때 총도 함께 활성화
        gun.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        gun.gameObject.SetActive(false);
    }

    private void Update()
    {
        //입력 처리
        if (playerInput.fire)
        {
            gun.Fire();
        }
        else if (playerInput.reload)
        {
            if (gun.Reload())
            {
                playerAnim.SetTrigger("Reload");
            }
        }

        UpdateUI();
    }
    
    void UpdateUI()
    {
        /*
        if (gun != null && UIManager.instance != null)
        {
            UIManager.instance.UpdateAmmoText(gun.magAmmo, gun.ammoRemain);
        }
        */
    }

    private void OnAnimatorIK(int layerIndex)
    {
        // 총의 기준점 gunPivot을 3D 모델의 오른쪽 팔꿈치 위치로 이동
        gunPivot.position = playerAnim.GetIKHintPosition(AvatarIKHint.RightElbow);

        // IK를 사용해 왼손의 위치와 회전을 총의 왼쪽 손잡이에 맞춘다
        playerAnim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
        playerAnim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);

        playerAnim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandMount.position);
        playerAnim.SetIKRotation(AvatarIKGoal.LeftHand, leftHandMount.rotation);

        // Ik를 사용해 오른손의 위치와 회전을 총의 오른쪽 손잡이에 맞춘다
        playerAnim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
        playerAnim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);

        playerAnim.SetIKPosition(AvatarIKGoal.RightHand, rightHandMount.position);
        playerAnim.SetIKRotation(AvatarIKGoal.RightHand, rightHandMount.rotation);
    }
}
