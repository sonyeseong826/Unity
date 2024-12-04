using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 탄알 이동 속도 지정
    public float speed = 1f;
    
    // 이동에 사용할 리지드바디 컴포넌트 선언
    private Rigidbody BulletRigidbody;

    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        BulletRigidbody = GetComponent<Rigidbody>();

        // BulletRigidbody.velocity(리저드바디에 일정한 속도) = transform.forward(현재 방향) * 이동속도 : 현재 방향으로 이동속도 만큼 이동
        BulletRigidbody.velocity = transform.forward * speed;

        // 3초뒤에 오브젝트 파괴
        Destroy(gameObject, 3f);
    }
    
    private void OnTriggerEnter(Collider other)
    // 트리거 충동시 자동실행 메서드
    {
        // 총동한 상대방 게임 오브젝트 태그가 Player 태그를 가진 경우
        if (other.tag == "Player")
        {
            // 상대방 오브젝트에서 PlayerController 안에 저장 되어있는 컴포넌트를 playerController에 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            // playerController 값이 null이 아니라면
            if (playerController != null)
            {
                // 상대방 PlayerController 컴포넌트의 Die() 매서드 실행
                playerController.Die();
            }
        }
    }
}
