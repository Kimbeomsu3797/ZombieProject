using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//스크립터블 오브젝트 메뉴 생성
[CreateAssetMenu(menuName = "Scriptable/GunData", fileName = "Gun Data")]
public class GunData : ScriptableObject
{
    public AudioClip audioClip;
    public AudioClip reloadClip;

    public float damage = 25;

    public int startAmmoRemain = 100;   //전체 탄약
    public int magCapacity = 25;        //탄창 용량

    public float timeBetFire = 0.12f;
    public float reloadTime = 1.8f;
}
