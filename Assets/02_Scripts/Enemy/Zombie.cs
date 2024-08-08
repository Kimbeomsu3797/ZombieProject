using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : LivingEntity
{
    public LayerMask whatIsTarget;

    LivingEntity targetEntity;
    NavMeshAgent navMeshAgent;

    public ParticleSystem hitEffect;
    public AudioClip deathSound;
    public AudioClip hitSound;

    Animator zomAnim;
    AudioSource zomAudio;
    Renderer zomRenderer;

    public float damage = 20f;
    public float timeBetAttack = 0.5f;
    float lastAttackTime;

    // 읽기 전용 프로퍼티
    bool hasTarget
    {
        get
        {
            if (targetEntity != null && !targetEntity.dead)
            {
                return true;
            }

            return false;
        }
    }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        zomAnim = GetComponent<Animator>();
        zomAudio = GetComponent<AudioSource>();

        zomRenderer = GetComponentInChildren<Renderer>();
    }

    public void Setup(ZombieData zombieData)
    {
        startingHealth = zombieData.health;
        health = startingHealth;

        damage = zombieData.damage;
        navMeshAgent.speed = zombieData.speed;
        zomRenderer.material.color = zombieData.skinColor;
    }

    private void Start()
    {
        StartCoroutine(UpdatePath());   
    }

    private void Update()
    {
        zomAnim.SetBool("HasTarget", hasTarget);
    }

    IEnumerator UpdatePath()
    {
        while (!dead)
        {
            if (hasTarget)
            {
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(targetEntity.transform.position);
            }
            else
            {
                navMeshAgent.isStopped = false;

                Collider[] colliders = Physics.OverlapSphere(transform.position, 20f, whatIsTarget);

                for (int i = 0; i < colliders.Length; i++)
                {
                    LivingEntity livingEntity = colliders[i].GetComponent<LivingEntity>();

                    if (livingEntity != null && !livingEntity.dead)
                    {
                        targetEntity = livingEntity;

                        break;
                    }
                }
            }
            yield return new WaitForSeconds(0.25f);
        }
    }

    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        if (!dead)
        {
            hitEffect.transform.position = hitPoint;
            hitEffect.transform.rotation = Quaternion.LookRotation(hitNormal);
            hitEffect.Play();

            zomAudio.PlayOneShot(hitSound);
        }

        base.OnDamage(damage, hitPoint, hitNormal);
    }

    public override void Die()
    {
        base.Die();

        Collider[] zombieColliders = GetComponents<Collider>();
        for (int i = 0; i < zombieColliders.Length; i++)
        {
            zombieColliders[i].enabled = false;
        }
        navMeshAgent.isStopped = true;
        navMeshAgent.enabled = false;

        zomAnim.SetTrigger("Die");

        zomAudio.PlayOneShot(deathSound);
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (!dead && Time.time >= lastAttackTime + timeBetAttack)
        {
            LivingEntity attackTarget = other.GetComponent<LivingEntity>();

            if (attackTarget != null && attackTarget == targetEntity)
            {
                lastAttackTime = Time.time;

                // 상대방의 피격 위치와 피격 방향을 근삿값으로 계산
                Vector3 hitPoint = other.ClosestPoint(transform.position);
                Vector3 hitNormal = transform.position - other.transform.position;

                attackTarget.OnDamage(damage, hitPoint, hitNormal);
            }
        }
    }
}
