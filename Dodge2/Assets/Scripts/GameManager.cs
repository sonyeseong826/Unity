using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ���̺귯��
using UnityEngine.SceneManagement; // �� ���� ���� ���̺귯��

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; //���ӿ��� �� Ȱ��ȭ�� �ؽ�Ʈ ������Ʈ
    public Text timeText; // ���� �ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text recordText; // �ְ� ����� ǥ���� �ؽ�Ʈ ������Ʈ

    private float surviveTime; // �����ð�
    private bool isGameover; // ���ӿ��� ����
    void Start()
    {
        surviveTime = 0f; // �����ð� �ʱ�ȭ
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ���ӿ����� �ƴ϶��
        if (!isGameover)
        {
            // �����ð� ����
            surviveTime += Time.deltaTime;

            // ������ ���� �ð��� timeText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
            timeText.text = "Time : " + (int)surviveTime;
        }
        else
        {
            // ���ӿ��� ���¿��� R Ű�� �����ٸ�
            if (Input.GetKey(KeyCode.R))
            {
                // SampleScene ���� �ε�
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    //���� ������ ���ӿ��� ���·� �����ϴ� �޼���
    public void EndGame()
    {
        // ���ӻ��¸� ������ ��ȯ
        isGameover = true;
        // ���ӿ��� �ؽ�Ʈ ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);

        //BestTime Ű�� ����� ���������� �ְ� ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // ���������� �ְ� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�
        if (surviveTime > bestTime) 
        {
            // �ְ� ��� ���� ���� ���� �ð� ������ ����
            bestTime = surviveTime;

            // ����� �ְ� ����� BestTime Ű�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        // �ְ� ����� recordText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
        recordText.text = "Best Time : " + (int)bestTime;
    }
}
