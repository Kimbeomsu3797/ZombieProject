using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LivingEntity : MonoBehaviour
{
    public float startingHealth = 100f; // ���� ü��
    public float health { get; protected set; } // ���� ü��
    public bool dead { get; protected set; } //��� ����
    public event Action onDeath; // ����� �ߵ��� ����Ʈ
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
