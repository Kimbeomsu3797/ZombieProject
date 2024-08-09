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
        /*Vector3 randomDirection = Random.insideUnitSphere * 20f; // 원하는 범위 내의 랜덤한 방향 벡터를 생성합니다.
        randomDirection += transform.position; // 랜덤 방향 벡터를 현재 위치에 더합니다.

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, 20f, NavMesh.AllAreas)) // 랜덤 위치가 NavMesh 위에 있는지 확인합니다.
        {
            return hit.position; // NavMesh 위의 랜덤 위치를 반환합니다.
        }
        else
        {
            return transform.position; // NavMesh 위의 랜덤 위치를 찾지 못한 경우 현재 위치를 반환합니다.
        }*/
        
        
        //center를 중심으로 반지름이 maxDistance인 구 안에서 랜덤한 위치 하나를 저장
        //random.insideUnitSphere는 반지름이 1인 구 안에서 랜덤한 한 점을 반환하는 프로퍼티
        Vector3 randomPos = Random.insideUnitSphere * distance + center; 
        //내비메시 샘플링의 결과 정보를 저장하는 변수
        NavMeshHit hit;

        //maxDistance의 반경 안에서 , randomPos에 가장 가까운 내비메시 위의 한 점을 찾음
        NavMesh.SamplePosition(randomPos, out hit, distance, NavMesh.AllAreas);
        //찾은 점 반환
        return hit.position;
    }
}
