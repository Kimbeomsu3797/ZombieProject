using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHealth : LivingEntity
{
    public Slider hpSlider;
    Animator anim;

    public AudioClip deathClip;
    public AudioClip hitClip;
    public AudioClip itemPickUpClip;

    AudioSource playerAudio;

    PlayerMovement playerMovement;
    PlayerShooter playerShooter;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooter = GetComponent<PlayerShooter>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        hpSlider.gameObject.SetActive(true);
        hpSlider.maxValue = startingHealth;
        hpSlider.value = health;

        playerMovement.enabled = true;
        playerShooter.enabled = true;
    }

    public override void RestoreHealth(float newHealth)
    {
        base.RestoreHealth(newHealth);

        hpSlider.value = health;
    }

    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        if (!dead)
        {
            playerAudio.PlayOneShot(hitClip);
        }

        base.OnDamage(damage, hitPoint, hitNormal);

        hpSlider.value = health;
    }

    public override void Die()
    {
        onDeath -= DeadAction;
        onDeath += DeadAction;

        base.Die();
    }

    void DeadAction()
    {
        hpSlider.gameObject.SetActive(false);

        playerAudio.PlayOneShot(deathClip);
        anim.SetTrigger("Die");

        playerMovement.enabled = false;
        playerShooter.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!dead)
        {
            IItem item = other.GetComponent<IItem>();

            if (item != null)
            {
                item.Use(gameObject);
                playerAudio.PlayOneShot(itemPickUpClip);
            }
        }
    }
}
