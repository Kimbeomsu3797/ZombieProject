using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour, IItem
{
    public float health = 50;

    public void Use(GameObject target)
    {
        LivingEntity life = target.GetComponent<LivingEntity>();

        if (life != null)
        {
            Debug.Log("체력을 증가했다 : " + health);
            life.RestoreHealth(health);
        }

        Destroy(gameObject);
    }
}
