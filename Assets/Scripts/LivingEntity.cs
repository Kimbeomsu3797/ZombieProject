using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float startingHealth = 100f; // 시작 체력
    public float health { get; protected set; } // 현재 체력
    public bool dead { get; protected set; } //사망 상태
    public event Action onDeath; // 사망시 발동할 이펙트

   //데미지를 입는 기능
    public virtual void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        
        throw new NotImplementedException();
        //데미지만큼 체력감소
        health -= damage;

        //체력이 0 이하 && 아직 죽지 않았다면 사망 처리 실행
        if(health <= 0 && !dead)
        {
            Die();
        }
    }

    //생명체가 활성화될때 상태를 리셋
    protected virtual void OnEnable()
    {
        dead = false;

        health = startingHealth;
    }
    
    public virtual void RestoreHealth(float newHealth)
    {
        if (dead)
        {
            //사망한거라 체력회복이 안됨
            return;
        }

        health += newHealth;
    }

    public virtual void Die()
    {
        // onDeath 이벤트에 등록된 메서드가 있다면 실행
        if(onDeath != null)
        {
            onDeath();
        }

        dead = true;
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
