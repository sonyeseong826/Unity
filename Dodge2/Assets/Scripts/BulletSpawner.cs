using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // 생성할 탄알의 원본 프리팹 변수
    public float spawnRateMin = 0.5f; // 최소 생성 주기 지정
    public float spawnRateMax = 3f;// 최대 생성 주기 지정

    private Transform target; // 발사할 대상 변수
    private float spawnRate; // 생성 주기 변수
    private float timeAfterSpawn;  // 최근 생성 이후 누적 시간 변수

    void Start()
    {

        // 최근 생성 이후 누적 시간 0으로 초기화
        timeAfterSpawn = 0f;

        // 탄알 생성 간격을 spawnRateMin, spawnRateMax 사이중 랜덤 지정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // PlayerController 컴포넌트를 가진 오브젝트를 찾아 위치,각도,사이즈 값을 구하기
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        // timeAfterSpawn(최근 생성 이후 시간) 갱신
        timeAfterSpawn += Time.deltaTime;

        // 최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        if(timeAfterSpawn > spawnRate)
        {
            // 누적된 시간을 리셋
            timeAfterSpawn = 0f;

            // bulletPrefab의 복제본을
            // transform.position 위치와 transform.rotation 각도로 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // 생선된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 생성
            bullet.transform.LookAt(target);
            
            // 다음번 생성 간격을 spawnRateMin, spawnRateMax 사이에서 랜덤 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }

    }
}
