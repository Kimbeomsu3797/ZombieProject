using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour, IItem
{
    public float health = 50;

    public void Use(GameObject target)
    {
        //target�� ü���� ȸ���ϴ� ó��
        Debug.Log("ü���� ȸ���ߴ� : " + health);
        /*
        LivingEntity lief = target.GetComponent<LivingEntity>();

        if(lief!=null)
        {
            life.RestoreHealth(health);
        }

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
