using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPack : MonoBehaviour, IItem
{
    public int ammo = 30;

    public void Use(GameObject target)
    {
        PlayerShooter playerShooter = target.GetComponent<PlayerShooter>();

        if (playerShooter != null && playerShooter.gun != null)
        {
            // target에 탄알을 추가하는 처리
            Debug.Log("탄알이 증가했다 : " + ammo);
            playerShooter.gun.ammoRemain += ammo;
        }

        Destroy(gameObject);
    }
}
