using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float startingHealth = 100f; // ���� ü��
    public float health { get; protected set; } // ���� ü��
    public bool dead { get; protected set; } //��� ����
    public event Action onDeath; // ����� �ߵ��� ����Ʈ

   //�������� �Դ� ���
    public virtual void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        
        throw new NotImplementedException();
        //��������ŭ ü�°���
        health -= damage;

        //ü���� 0 ���� && ���� ���� �ʾҴٸ� ��� ó�� ����
        if(health <= 0 && !dead)
        {
            Die();
        }
    }

    //����ü�� Ȱ��ȭ�ɶ� ���¸� ����
    protected virtual void OnEnable()
    {
        dead = false;

        health = startingHealth;
    }
    
    public virtual void RestoreHealth(float newHealth)
    {
        if (dead)
        {
            //����ѰŶ� ü��ȸ���� �ȵ�
            return;
        }

        health += newHealth;
    }

    public virtual void Die()
    {
        // onDeath �̺�Ʈ�� ��ϵ� �޼��尡 �ִٸ� ����
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
