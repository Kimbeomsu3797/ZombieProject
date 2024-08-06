using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ũ���ͺ� ������Ʈ �޴� ����
[CreateAssetMenu(menuName = "Scriptable/GunData", fileName = "Gun Data")]
public class GunData : ScriptableObject
{
    public AudioClip audioClip;
    public AudioClip reloadClip;

    public float damage = 25;

    public int startAmmoRemain = 100;   //��ü ź��
    public int magCapacity = 25;        //źâ �뷮

    public float timeBetFire = 0.12f;
    public float reloadTime = 1.8f;
}
