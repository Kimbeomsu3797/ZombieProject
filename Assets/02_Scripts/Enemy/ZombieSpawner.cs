using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    
    public Zombie zombiePrefab;
    
    public ZombieData[] zombieDatas; 
   
    public Transform[] spawnPoints;
    //������ ���� ��� �� ������ ���
    private List<Zombie> zombies = new List<Zombie>(); 
    
    private int wave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance != null && GameManager.instance.isGameover)
        {
            return;
        }
        if(zombies.Count <= 0)
        {
            SpawnWave();
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        UIManager.instance.UpdateWaveText(wave, zombies.Count);
    }
    
    void SpawnWave()
    {
        wave++;

        int spawnCount = Mathf.RoundToInt(wave * 1.5f); //RoundToInt�� �ݿø��Լ�

        for (int i = 0; i<spawnCount; i++)
        {
            CreateZombie();
        }
    }

    void CreateZombie()
    {
        ZombieData zombieData = zombieDatas[Random.Range(0, zombieDatas.Length)];

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Zombie zombie = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);

        zombie.Setup(zombieData);

        zombies.Add(zombie);
        // ������ onDeath Action�� ���ٽ����� �޼��� ���
        zombie.onDeath += () => zombies.Remove(zombie);
        zombie.onDeath += () => Destroy(zombie.gameObject, 10f);
        zombie.onDeath += () => GameManager.instance.AddScore(100);
    }
}
