using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float seppd = 8f;// �̵� �ӷ�

    private Rigidbody PlayerRigidbody; // �̵��� ����� ������ٵ� ������Ʈ
    void Start()
    {
        // ���� ������Ʈ���� Rigdbody  ������Ʈ�� ã�� playerRigidbody�� �Ҵ�
        PlayerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // ���� �̵��ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * seppd;
        float zSpeed = zInput * seppd;

        //Vector3 �ӵ��� (xSpeed, 0, zSpeed)�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0,zSpeed);

        // ������ٵ��� �ӵ��� newVelocity �Ҵ�
        PlayerRigidbody.velocity = newVelocity;
    }

    public void Die()
    { 
        //�ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);

        // ���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ� ��������
        GameManager gameManager = FindObjectOfType<GameManager>();
        
        // ������ GameManager ������Ʈ�� EndGame() �ż��� ����
        gameManager.EndGame();
    }
}
