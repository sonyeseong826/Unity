using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ������Ʈ�� ȸ�� ��Ű�� �ڵ�
public class Rotator : MonoBehaviour
{
    // ȸ�� �ӵ��� ����
    public float rotationSpeed = 60f;
    void Update()
    {
        // transform.Rotate�� Y���� ȸ�� ��Ŵ
        // Time.deltaTime�� �ʴ� ��� �ݺ��ϴ��� ���ϰ� ���� | (��) : 60 * 1/60 |
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
