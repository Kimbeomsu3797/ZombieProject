using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPack : MonoBehaviour, IItem
{
    public int ammo = 30;

    public void Use(GameObject target)
    {
        // Ÿ�ٿ� źȯ�� �߰��ϴ� ó��
        Debug.Log("ź���� �����ߴ� : " + ammo);

        /*
        // ���� ���� ���� ������Ʈ�κ��� PlayerShooter ������Ʈ�� �������� �õ�
        PlayerShooter playerShooter = target.GetComponent<PlayerShooter>();

        //PlayerShooter ������Ʈ�� ������, �� ������Ʈ�� �����ϸ�
        if(playerShooter != null && playerShooter.gun != null)
        {
            // ���� ���� źȯ ���� ammo ��ŭ ���Ѵ�
            playerShooter.gun.ammoRemain += ammo;
        }
        // ���Ǿ����Ƿ� �ڽ��� �ı�
        Destroy(gameObject);
        */
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
