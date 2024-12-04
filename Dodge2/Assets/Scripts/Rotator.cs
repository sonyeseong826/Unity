using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임 오브젝트를 회전 시키는 코드
public class Rotator : MonoBehaviour
{
    // 회전 속도를 지정
    public float rotationSpeed = 60f;
    void Update()
    {
        // transform.Rotate로 Y값을 회전 시킴
        // Time.deltaTime로 초당 몇번 반복하는지 구하고 곱함 | (예) : 60 * 1/60 |
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
