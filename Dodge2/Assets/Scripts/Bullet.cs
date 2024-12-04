using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // ź�� �̵� �ӵ� ����
    public float speed = 1f;
    
    // �̵��� ����� ������ٵ� ������Ʈ ����
    private Rigidbody BulletRigidbody;

    void Start()
    {
        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        BulletRigidbody = GetComponent<Rigidbody>();

        // BulletRigidbody.velocity(������ٵ� ������ �ӵ�) = transform.forward(���� ����) * �̵��ӵ� : ���� �������� �̵��ӵ� ��ŭ �̵�
        BulletRigidbody.velocity = transform.forward * speed;

        // 3�ʵڿ� ������Ʈ �ı�
        Destroy(gameObject, 3f);
    }
    
    private void OnTriggerEnter(Collider other)
    // Ʈ���� �浿�� �ڵ����� �޼���
    {
        // �ѵ��� ���� ���� ������Ʈ �±װ� Player �±׸� ���� ���
        if (other.tag == "Player")
        {
            // ���� ������Ʈ���� PlayerController �ȿ� ���� �Ǿ��ִ� ������Ʈ�� playerController�� ��������
            PlayerController playerController = other.GetComponent<PlayerController>();

            // playerController ���� null�� �ƴ϶��
            if (playerController != null)
            {
                // ���� PlayerController ������Ʈ�� Die() �ż��� ����
                playerController.Die();
            }
        }
    }
}
