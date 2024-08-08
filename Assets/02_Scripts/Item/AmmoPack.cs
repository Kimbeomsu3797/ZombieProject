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
            // target�� ź���� �߰��ϴ� ó��
            Debug.Log("ź���� �����ߴ� : " + ammo);
            playerShooter.gun.ammoRemain += ammo;
        }

        Destroy(gameObject);
    }
}
