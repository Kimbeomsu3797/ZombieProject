using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] items;
    public Transform playerTransform;

    public float maxDistance = 5f;

    public float timeBetSpawnMax = 7f;
    public float timeBetSpawnMin = 2f;

    private float timeBetSpawn;
    private float lastSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
        lastSpawnTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= lastSpawnTime + timeBetSpawn && playerTransform != null)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
            Spawn();
        }
    }
    private void Spawn()
    {
        Vector3 spawnPosition = GetRandomPointOnNavMesh(playerTransform.position, maxDistance);

        spawnPosition += Vector3.up * 0.5f;

        GameObject selectedItem = items[Random.Range(0, items.Length)];
        GameObject item = Instantiate(selectedItem, spawnPosition, Quaternion.identity);

        Destroy(item,5f);
    }
    private Vector3 GetRandomPointOnNavMesh(Vector3 center,float distance)
    {
        /*Vector3 randomDirection = Random.insideUnitSphere * 20f; // ���ϴ� ���� ���� ������ ���� ���͸� �����մϴ�.
        randomDirection += transform.position; // ���� ���� ���͸� ���� ��ġ�� ���մϴ�.

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, 20f, NavMesh.AllAreas)) // ���� ��ġ�� NavMesh ���� �ִ��� Ȯ���մϴ�.
        {
            return hit.position; // NavMesh ���� ���� ��ġ�� ��ȯ�մϴ�.
        }
        else
        {
            return transform.position; // NavMesh ���� ���� ��ġ�� ã�� ���� ��� ���� ��ġ�� ��ȯ�մϴ�.
        }*/
        
        
        //center�� �߽����� �������� maxDistance�� �� �ȿ��� ������ ��ġ �ϳ��� ����
        //random.insideUnitSphere�� �������� 1�� �� �ȿ��� ������ �� ���� ��ȯ�ϴ� ������Ƽ
        Vector3 randomPos = Random.insideUnitSphere * distance + center; 
        //����޽� ���ø��� ��� ������ �����ϴ� ����
        NavMeshHit hit;

        //maxDistance�� �ݰ� �ȿ��� , randomPos�� ���� ����� ����޽� ���� �� ���� ã��
        NavMesh.SamplePosition(randomPos, out hit, distance, NavMesh.AllAreas);
        //ã�� �� ��ȯ
        return hit.position;
    }
}
