using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float seppd = 8f;// 이동 속력

    private Rigidbody PlayerRigidbody; // 이동에 사용할 리지드바디 컴포넌트
    void Start()
    {
        // 게임 오브젝트에서 Rigdbody  컴포넌트를 찾아 playerRigidbody에 할당
        PlayerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동속도를 입력값과 이동 속력을 상용해 결정
        float xSpeed = xInput * seppd;
        float zSpeed = zInput * seppd;

        //Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0,zSpeed);

        // 리지드바디의 속도에 newVelocity 할당
        PlayerRigidbody.velocity = newVelocity;
    }

    public void Die()
    { 
        //자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);

        // 씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
        GameManager gameManager = FindObjectOfType<GameManager>();
        
        // 가져온 GameManager 오브젝트의 EndGame() 매서드 실행
        gameManager.EndGame();
    }
}
